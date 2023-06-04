using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    public BoxCollider enemyCollider;
    #region Fields
    private float rangeCollider = 4;
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
    void Start()
    {
        enemyCollider.center = new Vector3(0, 0, rangeCollider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
