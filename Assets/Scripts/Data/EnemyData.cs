using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public static EnemyData enemyData;
    public BoxCollider enemyCollider;
    #region Fields
    private float rangeCollider = 5;
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
    public float RateFire
    {
        get { return rateFire; }
        set
        {
            rateFire = value;
            rateFire = Mathf.Clamp(rateFire, .5f, 5);
        }
    }
    #endregion
    private void Awake()
    {
        enemyData = this;
    }
    void Start()
    {
        enemyCollider.size = new Vector3(1, .1f, rangeCollider);
        enemyCollider.center = new Vector3(0, 0, rangeCollider / 2);
    }
}
