using UnityEngine;

public class FireToEnemy : MonoBehaviour
{
    public GameObject playerBullet;
    private void OnTriggerEnter(Collider other)
    {
        Fire();
    }
    private void OnTriggerExit(Collider other)
    {
        CancelInvoke();
    }
    #region Fire
    void Fire()
    {
        InvokeRepeating("BulletSpawn", .5f, PlayerData.playerData.RateFire);
    }
    void BulletSpawn()
    {
        Instantiate(playerBullet, transform.position, Quaternion.identity, transform);
    }
    #endregion
}
