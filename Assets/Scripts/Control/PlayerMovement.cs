using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;
    public Animator playerAnim;
    public BoxCollider playerCollider;
    public GameObject playerShield;
    public Image healthBar;
    float lastFrameFingerPositionX;
    float moveFactorX;
    public float swerveSpeed = 1f;
    private void Awake()
    {
        player = this;
    }
    private void Start()
    {
        playerCollider.size = new Vector3(1f, .1f, PlayerData.playerData.RangeColider);
        playerCollider.center = new Vector3(0, 0, PlayerData.playerData.RangeColider / 2);
    }
    void Update()
    {
        GameUIManager.uý.ScoreIncrease();
        SwerveSystem();
        Move();
        if (transform.position.z > GameManager.manager.newLevelsPos)
        {
            GameManager.manager.NewLevels();
            GameManager.manager.newLevelsPos += GameManager.manager.posDifferent;
        }
    }
    #region Swerve
    public void SwerveSystem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
    #endregion
    #region Move
    public void Move()
    {
        playerAnim.SetBool("Run", true);
        float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;
        transform.Translate(x: swerveAmount, y: 0, z: Time.deltaTime * PlayerData.playerData.Speed);
        float posX = Mathf.Clamp(transform.position.x, -2, 2);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 8:
                NumberFind(other, 1f);
                break;
            case 9:
                NumberFind(other, -1f);
                break;
            case 10:
                CoinAdd(other);
                break;
            case 11:
                HealthAdd(other);
                break;
            case 12:
                TermScoreInc(other);
                break;
            case 13:
                ShieldAdd(other);
                break;
            case 14:
                SpeedAdd(other);
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 17)
        {
            PlayerData.playerData.Health = 0;
        }
    }
    #region GateCrash
    void NumberFind(Collider other, float result)
    {
        TextMeshProUGUI[] texts = other.GetComponentsInChildren<TextMeshProUGUI>();
        string count = texts[0].text.Substring(1, texts[0].text.Length - 1);
        float countNumber = (float)Convert.ToDouble(count) * result;
        switch (texts[1].text)
        {
            case "RANGE":
                PlayerData.playerData.RangeColider += countNumber;
                playerCollider.size = new Vector3(.1f, .1f, PlayerData.playerData.RangeColider);
                playerCollider.center = new Vector3(0, 0, PlayerData.playerData.RangeColider / 2);
                break;
            case "SHIELD":
                PlayerData.playerData.ShieldCount += (int)countNumber;
                GameUIManager.uý.shieldText.text = "" + PlayerData.playerData.ShieldCount;
                break;
            case "SPEED":
                PlayerData.playerData.Speed += countNumber;
                break;
            case "RATEFIRE":
                PlayerData.playerData.RateFire += countNumber;
                break;
            default:
                break;
        }
    }
    #endregion
    #region CoinAdd
    void CoinAdd(Collider other)
    {
        PlayerData.playerData.CoinCount += JsonSave.json.item.counts[0];
        GameUIManager.uý.coinText.text = "" + PlayerData.playerData.CoinCount;
        other.gameObject.SetActive(false);
    }
    #endregion
    #region HealthAdd
    void HealthAdd(Collider other)
    {
        PlayerData.playerData.Health += JsonSave.json.item.counts[1];
        other.gameObject.SetActive(false);
    }
    #endregion
    #region TermScoreIncrease
    void TermScoreInc(Collider other)
    {
        PlayerData.playerData.ScoreMultiply += JsonSave.json.item.counts[4]; ;
        GameUIManager.uý.scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
        StartCoroutine(TermFinished());
        other.gameObject.SetActive(false);
    }
    #endregion
    #region TermScoreIncreaseFinish
    IEnumerator TermFinished()
    {
        yield return new WaitForSeconds(JsonSave.json.item.counts[5]);
        PlayerData.playerData.ScoreMultiply -= JsonSave.json.item.counts[4]; ;
        GameUIManager.uý.scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
    }
    #endregion
    #region ShieldAdd
    void ShieldAdd(Collider other)
    {
        PlayerData.playerData.ShieldCount++;
        GameUIManager.uý.shieldText.text = "" + PlayerData.playerData.ShieldCount;
        other.gameObject.SetActive(false);
    }
    #endregion
    #region SpeedAdd
    void SpeedAdd(Collider other)
    {
        PlayerData.playerData.SpeedCount++;
        GameUIManager.uý.speedText.text = "" + PlayerData.playerData.SpeedCount;
        other.gameObject.SetActive(false);
    }
    #endregion
}
