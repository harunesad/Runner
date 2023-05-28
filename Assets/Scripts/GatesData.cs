using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesData : MonoBehaviour
{
    public static GatesData gatesData;
    #region Fields
    private int rangeColliderMultiply;
    private int shieldCountMultiply;
    private int speedMultiply;
    private int rateFireMultiply;
    #endregion
    #region Properties
    public int RangeColliderMultiply
    {
        get { return rangeColliderMultiply; }
        set { rangeColliderMultiply = value; }
    }
    public int ShieldCountMultiply
    {
        get { return shieldCountMultiply; }
        set { shieldCountMultiply = value; }
    }
    public int SpeedMultiply
    {
        get { return speedMultiply; }
        set { speedMultiply = value; }
    }
    public int RateFireMultiply
    {
        get { return rateFireMultiply; }
        set { rateFireMultiply = value; }
    }
    #endregion
    private void Awake()
    {
        gatesData = this;
    }
}
