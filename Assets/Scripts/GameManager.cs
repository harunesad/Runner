using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rangeCollider;
    public List<GameObject> levels;
    int levelCount = 1;
    BoxCollider bc;
    private void Awake()
    {
        bc = rangeCollider.GetComponent<BoxCollider>();
    }
    void Start()
    {
        bc.center = new Vector3(0, 0, PlayerData.playerData.RangeColider);
    }
    void Update()
    {
        UIManager.uý.ScoreIncrease();
    }
}
