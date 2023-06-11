using UnityEngine;
using DG.Tweening;

public class PlayerBulletMove : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveZ(transform.position.z + 5, .25f).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                Destroy(gameObject);
            });
    }
    private void OnTriggerEnter(Collider other)
    {
        Animator enemyAnim = other.GetComponent<Animator>();
        CapsuleCollider cc = other.GetComponent<CapsuleCollider>();
        FireToPlayer fireToPlayer = other.transform.GetChild(8).GetComponent<FireToPlayer>();
        fireToPlayer.CancelInvoke();
        FindObjectOfType<FireToEnemy>().CancelInvoke();
        enemyAnim.SetTrigger("Death");
        cc.enabled = false;
        Destroy(gameObject);
    }
}
