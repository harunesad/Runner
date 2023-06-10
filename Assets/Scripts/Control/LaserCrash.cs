using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrash : MonoBehaviour
{
    public static LaserCrash laser;
    private void Awake()
    {
        laser = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            HealthReduce();
        }
        if (other.gameObject.layer == 16)
        {
            ShieldClose();
        }
    }
    #region HealthReduce
    void HealthReduce()
    {
        PlayerData.playerData.Health -= ItemData.itemData.healthReduce;
    }
    #endregion
    #region ShieldClose
    public void ShieldClose()
    {
        StartCoroutine(TermShieldClose());
    }
    #endregion
    #region TermShieldColse
    IEnumerator TermShieldClose()
    {
        PlayerMovement.player.playerShield.SetActive(false);
        yield return new WaitForSeconds(.1f);
        PlayerMovement.player.playerShield.SetActive(true);
        yield return new WaitForSeconds(.1f);
        PlayerMovement.player.playerShield.SetActive(false);
        yield return new WaitForSeconds(.1f);
        PlayerMovement.player.playerShield.SetActive(true);
        yield return new WaitForSeconds(.1f);
        PlayerMovement.player.playerShield.SetActive(false);
    }
    #endregion
}