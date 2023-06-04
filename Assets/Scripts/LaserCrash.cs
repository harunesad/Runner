using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrash : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
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
        PlayerData.playerData.Health -= ItemData.itemData.HealthReduce;
        Debug.Log(PlayerData.playerData.Health);
    }
    #endregion
    #region ShieldClose
    void ShieldClose()
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
