using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToPlayer : MonoBehaviour
{
    public GameObject enemyBullet;
    private void OnTriggerEnter(Collider other)
    {
        Fire();
        GameObject parent = transform.parent.gameObject;
        parent.GetComponent<Animator>().SetBool("Fire", true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (Mathf.Abs(transform.position.x - other.transform.position.x) > 1)
        {
            CancelInvoke();
        }
    }
    void Fire()
    {
        InvokeRepeating("BulletSpawn", .5f, EnemyConroller.enemy.RateFire);
    }
    void BulletSpawn()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
        //Time.timeScale = 0;
    }
}
