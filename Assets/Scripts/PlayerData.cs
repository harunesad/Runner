using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData playerData;
    #region Fields
    private int rangeCollider = 3;
    private float scoreMultiply = 1;
    private int shieldCount = 0;
    private int speedChangeCount = 0;
    private float health = 100;
    private float speed = 3;
    private float rateFire = 3;
    #endregion
    #region Properties
    public int RangeColider
    {
        get { return rangeCollider; }
        set 
        { 
            rangeCollider += value; 
            rangeCollider = Mathf.Clamp(rangeCollider, 1, 6);
        }
    }
    public float ScoreMultiply
    {
        get { return scoreMultiply; }
        set 
        { 
            scoreMultiply += value;
            scoreMultiply = Mathf.Clamp(scoreMultiply, 1, 100);
        }
    }
    public int ShieldCount
    {
        get { return shieldCount; }
        set 
        { 
            shieldCount += value;
            shieldCount = Mathf.Clamp(shieldCount, 0, 10);
        }
    }
    public float Health
    {
        get { return health; }
        set
        {
            health += value;
            health = Mathf.Clamp(health, 0, 100);
        }
    }
    public float Speed
    {
        get { return speed; }
        set 
        {
            speed += value; 
            speed = Mathf.Clamp(speed, 1, 10);
            }
    }
    public float RateFire
    {
        get { return rateFire; }
        set 
        {
            rateFire = value;
            rateFire=Mathf.Clamp(rateFire, .5f, 5);
        }
    }
    #endregion
    private void Awake()
    {
        playerData = this;
    }
}