using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;
    public Animator playerAnim;
    public GameObject playerShield;
    float lastFrameFingerPositionX;
    float moveFactorX;
    public float swerveSpeed = 1f;
    float health;
    private void Awake()
    {
        player = this;
        playerAnim = GetComponent<Animator>();
        playerShield = transform.GetChild(9).gameObject;
    }
    private void Start()
    {
        health = PlayerData.playerData.Health;
    }
    void Update()
    {
        UIManager.uý.ScoreIncrease();
        SwerveSystem();
        Move();
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
                GameManager.manager.bc.center = new Vector3(0, 0, PlayerData.playerData.RangeColider);
                break;
            case "SHIELD":
                PlayerData.playerData.ShieldCount += (int)countNumber;
                UIManager.uý.shieldText.text = "" + PlayerData.playerData.ShieldCount;
                break;
            case "SPEED":
                PlayerData.playerData.Speed += countNumber;
                break;
            case "RATEFIRE":
                break;
            default:
                break;
        }
    }
    #endregion
    #region CoinAdd
    void CoinAdd(Collider other)
    {
        PlayerData.playerData.CoinCount += ItemData.itemData.CoinIncCount;
        UIManager.uý.coinText.text = "Coin " + PlayerData.playerData.CoinCount;
        Destroy(other.gameObject);
    }
    #endregion
    #region HealthAdd
    void HealthAdd(Collider other)
    {
        PlayerData.playerData.Health += ItemData.itemData.HealthInc;
        health = PlayerData.playerData.Health;
        Destroy(other.gameObject);
    }
    #endregion
    #region TermScoreIncrease
    void TermScoreInc(Collider other)
    {
        PlayerData.playerData.ScoreMultiply += ItemData.itemData.ScoreMultiplyInc;
        UIManager.uý.scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
        StartCoroutine(TermFinished());
        Destroy(other.gameObject);
    }
    #endregion
    #region TermScoreIncreaseFinish
    IEnumerator TermFinished()
    {
        yield return new WaitForSeconds(ItemData.itemData.ScoreMultiplyIncTime);
        PlayerData.playerData.ScoreMultiply -= ItemData.itemData.ScoreMultiplyInc;
        UIManager.uý.scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
    }
    #endregion
    #region ShieldAdd
    void ShieldAdd(Collider other)
    {
        PlayerData.playerData.ShieldCount++;
        UIManager.uý.shieldText.text = "" + PlayerData.playerData.ShieldCount;
        Destroy(other.gameObject);
    }
    #endregion
    #region SpeedAdd
    void SpeedAdd(Collider other)
    {
        PlayerData.playerData.SpeedCount++;
        UIManager.uý.speedText.text = "" + PlayerData.playerData.SpeedCount;
        Destroy(other.gameObject);
    }
    #endregion
}
