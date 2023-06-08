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
    public GameObject enemy;
    public float posDifferent, newLevelsPos;
    int levelCount;
    private void Awake()
    {
        manager = this;
    }
    void Start()
    {
        levelCount = 0;
        newLevelsPos = 72;
        posDifferent = levels[1].transform.GetChild(4).position.z - levels[0].transform.GetChild(4).position.z;
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
        }
    }
    void RandomItem(GameObject obj)
    {
        obj.SetActive(true);
        float randPosX = Random.Range(-2f, 2f);
        float randPosZ = Random.Range(pos[0].minPosZ, pos[0].maxPosZ);
        obj.transform.position = new Vector3(randPosX, obj.transform.position.y, randPosZ);
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
        float randPosZ = Random.Range(pos[0].minPosZ, pos[0].maxPosZ);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, randPosZ);
        pos.RemoveAt(0);
    }
    public void NewLevels()
    {
        if (levelCount == 0)
        {
            StartCoroutine(NewLevel(0, 4));
        }
        else
        {
            StartCoroutine(NewLevel(levelCount, levelCount - 1));
        }
    }
    IEnumerator NewLevel(int posLevelCount, int posZlevelCount)
    {
        GameObject enemy = levels[levelCount].transform.GetChild(0).gameObject;
        enemy.GetComponent<Animator>().SetBool("NewAnimation", true);
        if (enemy.GetComponent<CapsuleCollider>().enabled == false)
        {
            enemy.GetComponent<CapsuleCollider>().enabled = true;
        }

        yield return new WaitForSeconds(1);
        Vector3 levelPos = levels[posLevelCount].transform.position;
        levels[levelCount].transform.position = new Vector3(levelPos.x, levelPos.y, levels[posZlevelCount].transform.position.z + posDifferent);
        int random = Random.Range(5, 10);
        for (int i = 5; i < levels[levelCount].transform.childCount; i++)
        {
            if (levels[levelCount].transform.GetChild(i).gameObject.activeSelf)
            {
                levels[levelCount].transform.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }
        RandomItem(levels[levelCount].transform.GetChild(random).gameObject);
        RandomEnemyPos(levels[levelCount].transform.GetChild(0).gameObject);
        RandomTrapPos(levels[levelCount].transform.GetChild(3).gameObject);
        for (int j = 0; j < newPos.Count; j++)
        {
            newPos[j].minPosZ += posDifferent;
            newPos[j].maxPosZ += posDifferent;
        }
        pos.AddRange(newPos);
        levelCount++;
        if (levelCount == 5)
        {
            levelCount = 0;
        }
        enemy.GetComponent<Animator>().SetBool("NewAnimation", false);
    }
}
[System.Serializable]
public class randomPos
{
    public float minPosZ;
    public float maxPosZ;
}
