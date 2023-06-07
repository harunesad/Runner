using System;
using System.Collections;
using System.Collections.Generic;
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
        TextMeshProUGUI[] countPositive = gatePositive.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] countNegative = gateNegative.GetComponentsInChildren<TextMeshProUGUI>();
        float randomCount = Random.Range(.1f, .5f);
        countPositive[0].text = "+" + Math.Round(randomCount, 1);
        countNegative[0].text = "-" + Math.Round(randomCount, 1);
        countPositive[1].text = "RANGE";
        countNegative[1].text = "RANGE";
    }
    void GateShield(GameObject gatePositive, GameObject gateNegative)
    {
        TextMeshProUGUI[] countPositive = gatePositive.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] countNegative = gateNegative.GetComponentsInChildren<TextMeshProUGUI>();
        countPositive[0].text = "+" + 1;
        countNegative[0].text = "-" + 1;
        countPositive[1].text = "SHIELD";
        countNegative[1].text = "SHIELD";
    }
    void GateSpeed(GameObject gatePositive, GameObject gateNegative)
    {
        TextMeshProUGUI[] countPositive = gatePositive.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] countNegative = gateNegative.GetComponentsInChildren<TextMeshProUGUI>();
        float randomCount = Random.Range(.1f, .5f);
        countPositive[0].text = "+" + Math.Round(randomCount, 1);
        countNegative[0].text = "-" + Math.Round(randomCount, 1);
        countPositive[1].text = "SPEED";
        countNegative[1].text = "SPEED";
    }
    void GateRateFire(GameObject gatePositive, GameObject gateNegative)
    {
        TextMeshProUGUI[] countPositive = gatePositive.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] countNegative = gateNegative.GetComponentsInChildren<TextMeshProUGUI>();
        countPositive[0].text = "+" + .1f;
        countNegative[0].text = "-" + .1f;
        countPositive[1].text = "RATEFIRE";
        countNegative[1].text = "RATEFIRE";
    }
    #endregion
    private void Awake()
    {
        gatesControl = this;
    }
}
