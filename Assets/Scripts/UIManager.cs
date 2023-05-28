using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uý;
    public TextMeshProUGUI startNumberText, scoreText, scoreMultiplyText;
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
        scoreMultiplyText.text = "x" + PlayerData.playerData.ScoreMultiply;
        StartCoroutine(GameStart());
    }
    private void Update()
    {
        ScoreIncrease();
    }
    #region ScoreAndMultiply
    public void ScoreIncrease()
    {
        score += Time.deltaTime * PlayerData.playerData.ScoreMultiply * 2;
        scoreText.text = "" + Mathf.FloorToInt(score);
        if (score > scoreIncMultiply)
        {
            PlayerData.playerData.ScoreMultiply = .1f;
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
