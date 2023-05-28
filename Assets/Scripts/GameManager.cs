using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject rangeCollider;
    public List<GameObject> levels;
    int levelCount = 1;
    public BoxCollider bc;
    private void Awake()
    {
        manager = this;
        bc = rangeCollider.GetComponent<BoxCollider>();
    }
    void Start()
    {
        bc.center = new Vector3(0, 0, PlayerData.playerData.RangeColider);
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
