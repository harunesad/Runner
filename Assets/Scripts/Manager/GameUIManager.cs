using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager uý;
    public TextMeshProUGUI startNumberText, scoreText, scoreMultiplyText, coinText, shieldText, speedText;
    public Button shieldButton, speedButton;
    int startNumber;
    float scoreIncMultiply = 100;
    float score = 0;
    private void Awake()
    {
        uý = this;
    }
    void Start()
    {
        JsonSave.json.StartSave();
        startNumber = 3;
        startNumberText.text = startNumber.ToString();
        scoreText.text = "" + score;
        PlayerData.playerData.ScoreMultiply = JsonSave.json.item.counts[3]; ;
        scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
        PlayerData.playerData.ShieldCount = (int)JsonSave.json.item.counts[6]; ;
        shieldText.text = "" + PlayerData.playerData.ShieldCount;
        PlayerData.playerData.SpeedCount = (int)JsonSave.json.item.counts[7]; ;
        speedText.text = "" + PlayerData.playerData.SpeedCount;
        coinText.text = "" + PlayerData.playerData.CoinCount;

        speedButton.onClick.AddListener(SpeedSlow);
        shieldButton.onClick.AddListener(ShieldOpen);

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
    #region SpeedSlow
    void SpeedSlow()
    {
        if (PlayerData.playerData.SpeedCount > 0 && PlayerMovement.player.playerAnim.speed == 1 && startNumber == 0)
        {
            PlayerData.playerData.Speed /= 2;
            PlayerMovement.player.playerAnim.speed /= 2;
            PlayerData.playerData.SpeedCount--;
            speedText.text = "" + PlayerData.playerData.SpeedCount;
            StartCoroutine(TermFinished());
        }
    }
    #endregion
    #region TermScoreIncreaseFinish
    IEnumerator TermFinished()
    {
        yield return new WaitForSeconds(JsonSave.json.item.counts[8]);
        PlayerData.playerData.Speed *= 2;
        PlayerMovement.player.playerAnim.speed *= 2;
    }
    #endregion
    #region ShieldOpen
    void ShieldOpen()
    {
        if (PlayerData.playerData.ShieldCount > 0 && !PlayerMovement.player.playerShield.activeSelf && startNumber == 0)
        {
            PlayerMovement.player.playerShield.SetActive(true);
            PlayerData.playerData.ShieldCount--;
            shieldText.text = "" + PlayerData.playerData.ShieldCount;
        }
    }
    #endregion
}
