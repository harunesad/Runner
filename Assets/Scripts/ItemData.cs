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
    #endregion
    private void Awake()
    {
        itemData = this;
    }
}
