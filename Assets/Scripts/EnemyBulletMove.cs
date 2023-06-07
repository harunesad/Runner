using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBulletMove : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveZ(transform.position.z - 5, .25f).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                Destroy(gameObject);
            });
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            CapsuleCollider cc = other.GetComponent<CapsuleCollider>();
            PlayerMovement.player.playerAnim.SetTrigger("Death");
            FindObjectOfType<PlayerMovement>().enabled = false;
            Debug.Log(gameObject.name);
            Destroy(cc);
            Destroy(other.gameObject, 3);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 16)
        {
            LaserCrash.laser.ShieldClose();
        }
    }
}
