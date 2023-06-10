using System.Collections.Generic;

[System.Serializable]
public class ItemData
{
    public static ItemData itemData;
    //public int MyProperty;
    #region CoinFields
    public List<int> coins;
    public int coinIncCountCoin;
    public int healthIncCoin;
    public int healthReduceCoin;
    public int scoreMultiplyStartCountCoin;
    public int scoreMultiplyIncCoin;
    public int scoreMultiplyIncTimeCoin;
    public int shieldStartCountCoin;
    public int speedStartCountCoin;
    public int speedSlowTimeCoin;
    #endregion
    #region CountFields
    public List<float> counts;
    public float coinIncCount;
    public float healthInc;
    public float healthReduce;
    public float scoreMultiplyStartCount;
    public float scoreMultiplyInc;
    public float scoreMultiplyIncTime;
    public float shieldStartCount;
    public float speedStartCount;
    public float speedSlowTime;
    #endregion
    //#region CoinProperties
    //public int CoinIncCountCoin
    //{
    //    get { return coinIncCountCoin; }
    //    set { coinIncCountCoin = value; }
    //}
    //public int HealthIncCoin
    //{
    //    get { return healthIncCoin; }
    //    set { healthIncCoin = value; }
    //}
    //public int HealthReduceCoin
    //{
    //    get { return healthReduceCoin; }
    //    set { healthReduceCoin = value; }
    //}
    //public int ScoreMultiplyStartCountCoin
    //{
    //    get { return scoreMultiplyStartCountCoin; }
    //    set { scoreMultiplyStartCountCoin = value; }
    //}
    //public int ScoreMultiplyIncCoin
    //{
    //    get { return scoreMultiplyIncCoin; }
    //    set { scoreMultiplyIncCoin = value; }
    //}
    //public int ScoreMultiplyIncTimeCoin
    //{
    //    get { return scoreMultiplyIncTimeCoin; }
    //    set { scoreMultiplyIncTimeCoin = value; }
    //}
    //public int SheildStartCountCoin
    //{
    //    get { return sheildStartCountCoin; }
    //    set { sheildStartCountCoin = value; }
    //}
    //public int SpeedStartCountCoin
    //{
    //    get { return speedStartCountCoin; }
    //    set { speedStartCountCoin = value; }
    //}
    //public int SpeedSlowTimeCoin
    //{
    //    get { return speedSlowTimeCoin; }
    //    set { speedSlowTimeCoin = value; }
    //}
    //#endregion
    //#region CountProperties
    //public float CoinIncCount
    //{
    //    get { return coinIncCount; }
    //    set { coinIncCount = value; }
    //}
    //public float HealthInc
    //{
    //    get { return healthInc; }
    //    set { healthInc = value; }
    //}
    //public float HealthReduce
    //{
    //    get { return healthReduce; }
    //    set { healthReduce = value; }
    //}
    //public float ScoreMultiplyStartCount
    //{
    //    get { return scoreMultiplyStartCount; }
    //    set { scoreMultiplyStartCount = value; }
    //}
    //public float ScoreMultiplyInc
    //{
    //    get { return scoreMultiplyInc; }
    //    set { scoreMultiplyInc = value; }
    //}
    //public float ScoreMultiplyIncTime
    //{
    //    get { return scoreMultiplyIncTime; }
    //    set { scoreMultiplyIncTime = value; }
    //}
    //public float ShieldStartCount
    //{
    //    get { return shieldStartCount; }
    //    set { shieldStartCount = value; }
    //}
    //public float SpeedStartCount
    //{
    //    get { return speedStartCount; }
    //    set { speedStartCount = value; }
    //}
    //public float SpeedSlowTime
    //{
    //    get { return speedSlowTime; }
    //    set { speedSlowTime = value; }
    //}
    //#endregion
    private void Awake()
    {
        itemData = this;
    }
}
