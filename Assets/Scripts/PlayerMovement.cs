using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;
    Animator playerAnim;
    float lastFrameFingerPositionX;
    float moveFactorX;
    public float swerveSpeed = 1f;
    float health;
    private void Awake()
    {
        player = this;
        playerAnim = GetComponent<Animator>();
    }
    private void Start()
    {
        health = PlayerData.playerData.Health;
    }
    void Update()
    {
        UIManager.u�.ScoreIncrease();
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
        Debug.Log(PlayerData.playerData.Speed);
        playerAnim.SetBool("Run", true);
        float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;
        transform.Translate(x: swerveAmount, y: 0, z: Time.deltaTime * PlayerData.playerData.Speed);
        float posX = Mathf.Clamp(transform.position.x, -2, 2);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
    #endregion
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8)
        {
            NumberFind(other, 1f);
        }
        if (other.gameObject.layer == 9)
        {
            NumberFind(other, -1f);
        }
        if (other.gameObject.layer == 10)
        {
            CoinAdd(other);
        }
        if (other.gameObject.layer == 11)
        {
            HealthAdd(other);
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
        UIManager.u�.coinText.text = "Coin " + PlayerData.playerData.CoinCount;
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
}
