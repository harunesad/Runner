using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PlayerData : MonoBehaviour
{
    public static PlayerData playerData;
    #region Fields
    private float rangeCollider = 4;
    private float scoreMultiply = 1;
    private int shieldCount;
    private int speedCount;
    private float health = 100;
    private float speed = 3;
    private float rateFire = 2;
    #endregion
    #region Properties
    public float RangeColider
    {
        get { return rangeCollider; }
        set 
        { 
            rangeCollider = value; 
            rangeCollider = Mathf.Clamp(rangeCollider, 1, 6);
        }
    }
    public float ScoreMultiply
    {
        get { return scoreMultiply; }
        set 
        { 
            scoreMultiply = value;
            scoreMultiply = Mathf.Clamp(scoreMultiply, 1, 100);
        }
    }
    public int ShieldCount
    {
        get { return shieldCount; }
        set 
        { 
            shieldCount = value;
            shieldCount = Mathf.Clamp(shieldCount, 0, 10);
        }
    }
    public int SpeedCount
    {
        get { return speedCount; }
        set
        {
            speedCount = value;
            speedCount = Mathf.Clamp(speedCount, 0, 10);
        }
    }
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            health = Mathf.Clamp(health, 0, 100);
            PlayerMovement.player.healthBar.DOFillAmount(health / 100, 1).SetEase(Ease.Linear);
            if (health == 0)
            {
                PlayerMovement.player.playerAnim.SetTrigger("Death");
                FindObjectOfType<PlayerMovement>().enabled = false;
                HighScoreSave();
            }
        }
    }
    public float Speed
    {
        get { return speed; }
        set 
        {
            speed = value; 
            speed = Mathf.Clamp(speed, 1, 10);
        }
    }
    public float RateFire
    {
        get { return rateFire; }
        set 
        {
            rateFire = value;
            rateFire = Mathf.Clamp(rateFire, .5f, 5);
        }
    }
    public float CoinCount
    {
        get { return PlayerPrefs.GetFloat("Coin"); }
        set
        {
            PlayerPrefs.SetFloat("Coin", value);
        }
    }
    #endregion
    private void Awake()
    {
        playerData = this;
    }
    #region HighScoreSave
    public void HighScoreSave()
    {
        PlayerPrefs.SetFloat("HighScore", GameUIManager.u�.score);
        for (int i = 0; i < JsonSave.json.item.highScore.Count; i++)
        {
            if (Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore")) > Mathf.FloorToInt(JsonSave.json.item.highScore[i].highScore))
            {
                JsonSave.json.item.highScore[5].highScore = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore"));
                JsonSave.json.item.highScore = JsonSave.json.item.highScore.OrderByDescending(x => x.highScore).ToList();
                SaveManager.Save(JsonSave.json.item);
                break;
            }
        }
    }
    #endregion
}

