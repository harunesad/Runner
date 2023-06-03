using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uý;
    public TextMeshProUGUI startNumberText, scoreText, scoreMultiplyText, coinText, shieldText, speedText;
    int startNumber;
    float scoreIncMultiply = 100;
    float score = 0;
    private void Awake()
    {
        uý = this;
    }
    void Start()
    {
        startNumber = 3;
        startNumberText.text = startNumber.ToString();
        scoreText.text = "" + score;
        PlayerData.playerData.ScoreMultiply = ItemData.itemData.ScoreMultiplyStartCount;
        scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
        PlayerData.playerData.ShieldCount = ItemData.itemData.ShieldStartCount;
        shieldText.text = "" + PlayerData.playerData.ShieldCount;
        PlayerData.playerData.SpeedCount = ItemData.itemData.SpeedStartCount;
        speedText.text = "" + PlayerData.playerData.SpeedCount;
        coinText.text = "" + PlayerData.playerData.CoinCount;
        StartCoroutine(GameStart());
    }
    private void Update()
    {
        
    }
    #region ScoreAndMultiply
    public void ScoreIncrease()
    {
        score += Time.deltaTime * PlayerData.playerData.ScoreMultiply * 2;
        scoreText.text = "" + Mathf.FloorToInt(score);
        if (score > scoreIncMultiply)
        {
            PlayerData.playerData.ScoreMultiply += .1f;
            scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
            scoreIncMultiply += scoreIncMultiply;
        }
    }
    #endregion
    #region GameStart
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        startNumber--;
        startNumberText.text = startNumber.ToString();
        yield return new WaitForSeconds(1);
        startNumber--;
        startNumberText.text = startNumber.ToString();
        yield return new WaitForSeconds(1);
        startNumber--;
        startNumberText.text = startNumber.ToString();
        yield return new WaitForSeconds(.25f);
        startNumberText.gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().enabled = true;
        //FindObjectOfType<GameManager>().enabled = true;
    }
    #endregion
}
