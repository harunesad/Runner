using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GatesControl : MonoBehaviour
{
    float sa = 5;
    enum GatesState
    {
        Range,
        Shield,
        Speed,
        RateFire
    }
    private void Start()
    {
        int randomGate = Random.Range(0, 4);
        switch (randomGate)
        {
            case 0:
                GatesResult(GatesState.Range);
                break;
            case 1:
                GatesResult(GatesState.Shield);
                break;
            case 2:
                GatesResult(GatesState.Speed);
                break;
            case 3:
                GatesResult(GatesState.RateFire);
                break;
            default:
                break;
        }
    }
    void GatesResult(GatesState gatesState)
    {
        switch (gatesState)
        {
            case GatesState.Range:
                break;
            case GatesState.Shield:
                break;
            case GatesState.Speed:
                break;
            case GatesState.RateFire:
                break;
            default:
                break;
        }
    }
}
