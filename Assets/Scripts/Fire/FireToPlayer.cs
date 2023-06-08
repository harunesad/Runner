using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToPlayer : MonoBehaviour
{
    public GameObject enemyBullet;
    GameObject parent;
    private void Start()
    {
        parent = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        Fire();
        parent.GetComponent<Animator>().SetBool("Fire", true);
    }
    private void OnTriggerExit(Collider other)
    {
        parent.GetComponent<Animator>().SetBool("Fire", false);
        CancelInvoke();
    }
    void Fire()
    {
        InvokeRepeating("BulletSpawn", .5f, EnemyData.enemyData.RateFire);
    }
    void BulletSpawn()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity, transform);
        //Time.timeScale = 0;
    }
}
