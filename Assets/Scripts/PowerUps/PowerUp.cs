using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp: MonoBehaviour
{

    [SerializeField]
    private float powerupCd;
    [SerializeField]
    private poweruptype powerUpType;

    private void Loot(PlayerManager playerManager)
    {
        playerManager.activarBufo(powerUpType, powerupCd);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)

    {
        var player = other.GetComponent<PlayerManager>();
        if (player!=null)
        {
            Loot(player);

        }

    }





}

public enum poweruptype
{

    bulletbufo,


}