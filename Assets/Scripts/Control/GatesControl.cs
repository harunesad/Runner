using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GatesControl : MonoBehaviour
{
    public static GatesControl gatesControl;
    #region GatesState
    enum GatesState
    {
        Range,
        Shield,
        Speed,
        RateFire
    }
    #endregion
    #region GateRandom
    public void GateRandom(GameObject gatePositive, GameObject gateNegative)
    {
        int randomGate = Random.Range(0, 4);
        switch (randomGate)
        {
            case 0:
                GatesResult(GatesState.Range, gatePositive, gateNegative);
                break;
            case 1:
                GatesResult(GatesState.Shield, gatePositive, gateNegative);
                break;
            case 2:
                GatesResult(GatesState.Speed, gatePositive, gateNegative);
                break;
            case 3:
                GatesResult(GatesState.RateFire, gatePositive, gateNegative);
                break;
            default:
                break;
        }
    }
    #endregion
    #region GateResult
    void GatesResult(GatesState gatesState, GameObject gatePositive, GameObject gateNegative)
    {
        switch (gatesState)
        {
            case GatesState.Range:
                GateRange(gatePositive, gateNegative);
                break;
            case GatesState.Shield:
                GateShield(gatePositive, gateNegative);
                break;
            case GatesState.Speed:
                GateSpeed(gatePositive, gateNegative);
                break;
            case GatesState.RateFire:
                GateRateFire(gatePositive, gateNegative);
                break;
            default:
                break;
        }
    }
    #endregion
    #region GateOperations
    void GateRange(GameObject gatePositive, GameObject gateNegative)
    {
        float randomCount = Random.Range(.1f, .5f);
        GeneralGate(gatePositive, gateNegative, (float)Math.Round(randomCount, 1), "RANGE");
    }
    void GateShield(GameObject gatePositive, GameObject gateNegative)
    {
        GeneralGate(gatePositive, gateNegative, 1, "SHIELD");
    }
    void GateSpeed(GameObject gatePositive, GameObject gateNegative)
    {
        float randomCount = Random.Range(.1f, .5f);
        GeneralGate(gatePositive, gateNegative, (float)Math.Round(randomCount, 1), "SPEED");
    }
    void GateRateFire(GameObject gatePositive, GameObject gateNegative)
    {
        GeneralGate(gatePositive, gateNegative, .1f, "RATEFIRE");
    }
    void GeneralGate(GameObject gatePositive, GameObject gateNegative, float value, string gateName)
    {
        TextMeshProUGUI[] countPositive = gatePositive.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] countNegative = gateNegative.GetComponentsInChildren<TextMeshProUGUI>();
        countPositive[0].text = "+" + value;
        countNegative[0].text = "-" + value;
        countPositive[1].text = gateName;
        countNegative[1].text = gateName;
    }
    #endregion
    private void Awake()
    {
        gatesControl = this;
    }
}
