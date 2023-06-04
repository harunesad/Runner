using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject rangeCollider;
    public List<GameObject> levels;
    int levelCount = 1;
    private void Awake()
    {
        manager = this;
    }
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            GatesControl.gatesControl.GateRandom(levels[i].transform.GetChild(1).gameObject, levels[i].transform.GetChild(2).gameObject);
        }
    }
    //void Update()
    //{
    //    UIManager.uý.ScoreIncrease();
    //}
}
