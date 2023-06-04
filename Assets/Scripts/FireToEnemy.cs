using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToEnemy : MonoBehaviour
{
    public GameObject playerBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Fire();
    }
    void Fire()
    {
        InvokeRepeating("BulletSpawn", .5f, PlayerData.playerData.RateFire);
    }
    void BulletSpawn()
    {
        Instantiate(playerBullet, transform.position, Quaternion.identity);
    }

}
