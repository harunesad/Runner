using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static ItemData itemData;
    #region Fields

    #endregion
    #region Properties
    public float CoinIncCount
    {
        get
        {
            if (PlayerPrefs.HasKey("CoinInc"))
            {
                return PlayerPrefs.GetFloat("CoinInc");
            }
            else
            {
                return 1;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("CoinInc", value);
        }
    }
    public float HealthInc
    {
        get
        {
            if (PlayerPrefs.HasKey("HealthInc"))
            {
                return PlayerPrefs.GetFloat("HealthInc");
            }
            else
            {
                return 10;
            }
        }
        set { PlayerPrefs.SetFloat("HealthInc", value); }
    }
    public float HealthReduce
    {
        get
        {
            if (PlayerPrefs.HasKey("HealthReduce"))
            {
                return PlayerPrefs.GetFloat("HealthReduce");
            }
            else
            {
                return 25;
            }
        }
        set 
        { 
            PlayerPrefs.SetFloat("HealthReduce", value);
        }
    }

    public float ScoreMultiplyStartCount
    {
        get
        {
            if (PlayerPrefs.HasKey("ScoreMultiply"))
            {
                return PlayerPrefs.GetFloat("ScoreMultiply");
            }
            else
            {
                return 1f;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("ScoreMultiply", value);
        }
    }
    public float ScoreMultiplyInc
    {
        get
        {
            if (PlayerPrefs.HasKey("ScoreMultiplyInc"))
            {
                return PlayerPrefs.GetFloat("ScoreMultiplyInc");
            }
            else
            {
                return .1f;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("ScoreMultiplyInc", value);
        }
    }
    public float ScoreMultiplyIncTime
    {
        get
        {
            if (PlayerPrefs.HasKey("ScoreMultiplyIncTime"))
            {
                return PlayerPrefs.GetFloat("ScoreMultiplyIncTime");
            }
            else
            {
                return 3f;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("ScoreMultiplyIncTime", value);
        }
    }
    public int ShieldStartCount
    {
        get
        {
            if (PlayerPrefs.HasKey("ShieldStart"))
            {
                return PlayerPrefs.GetInt("ShieldStart");
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("ShieldStart", value);
        }
    }
    public int SpeedStartCount
    {
        get
        {
            if (PlayerPrefs.HasKey("SpeedStart"))
            {
                return PlayerPrefs.GetInt("SpeedStart");
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("SpeedStart", value);
        }
    }
    public float SpeedSlowTime
    {
        get
        {
            if (PlayerPrefs.HasKey("SpeedSlowTime"))
            {
                return PlayerPrefs.GetInt("SpeedSlowTime");
            }
            else
            {
                return 3f;
            }
        }
        set
        {
            PlayerPrefs.SetFloat("SpeedSlowTime", value);
        }
    }
    #endregion
    private void Awake()
    {
        itemData = this;
    }
}
