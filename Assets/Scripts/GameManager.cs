using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject rangeCollider;
    public List<GameObject> levels;
    public List<randomPos> pos;
    public List<randomPos> newPos;
    public List<GameObject> items;
    public GameObject enemy;
    float posDifferent;
    int levelCount;
    private void Awake()
    {
        manager = this;
    }
    void Start()
    {
        posDifferent = levels[1].transform.GetChild(4).position.z - levels[0].transform.GetChild(4).position.z;
        Debug.Log(posDifferent);
        for (int i = 0; i < 5; i++)
        {
            GatesControl.gatesControl.GateRandom(levels[i].transform.GetChild(1).gameObject, levels[i].transform.GetChild(2).gameObject);
            int random = Random.Range(5, 10);
            RandomItem(levels[i].transform.GetChild(random).gameObject);
            RandomEnemyPos(levels[i].transform.GetChild(0).gameObject);
            RandomTrapPos(levels[i].transform.GetChild(3).gameObject);
            for (int j = 0; j < newPos.Count; j++)
            {
                newPos[j].minPosZ += posDifferent;
                newPos[j].maxPosZ += posDifferent;
            }
            pos.AddRange(newPos);
            Debug.Log(levels[i].transform.GetChild(random).gameObject.transform.position.z);
            Debug.Log(levels[i].transform.GetChild(random).gameObject.name);
            Debug.Log(levels[i].transform.GetChild(random).gameObject.transform.parent.name);
        }
    }
    void RandomItem(GameObject obj)
    {
        obj.SetActive(true);
        float randPosX = Random.Range(-2f, 2f);
        float randPosZ = Random.Range(pos[0].minPosZ, pos[0].maxPosZ);
        obj.transform.position = new Vector3(randPosX, obj.transform.position.y, randPosZ);
        Debug.Log(randPosZ);
        pos.RemoveAt(0);
    }
    void RandomEnemyPos(GameObject obj)
    {
        int rand = Random.Range(0, pos.Count);
        float randPosX = Random.Range(-2f, 2f);
        float randPosZ = Random.Range(pos[rand].minPosZ, pos[rand].maxPosZ);
        obj.transform.position = new Vector3(randPosX, obj.transform.position.y, randPosZ);
        pos.RemoveAt(rand);
    }
    void RandomTrapPos(GameObject obj)
    {
        float randPosX = Random.Range(-2f, 2f);
        float randPosZ = Random.Range(pos[0].minPosZ, pos[0].maxPosZ);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, randPosZ);
        pos.RemoveAt(0);
    }
}
[System.Serializable]
public class randomPos
{
    public float minPosZ;
    public float maxPosZ;
}
