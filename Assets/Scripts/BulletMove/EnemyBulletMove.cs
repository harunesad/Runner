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
            transform.parent.parent.GetComponent<Animator>().SetBool("Fire", false);
            PlayerData.playerData.Health = 0;
            FireToPlayer fireToPlayer = transform.parent.GetComponent<FireToPlayer>();
            fireToPlayer.CancelInvoke();
            FindObjectOfType<FireToEnemy>().CancelInvoke();
            CapsuleCollider cc = other.GetComponent<CapsuleCollider>();
            Destroy(cc);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 16)
        {
            LaserCrash.laser.ShieldClose();
            Destroy(gameObject);
        }
    }
}
