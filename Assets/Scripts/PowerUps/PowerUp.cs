using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp: MonoBehaviour
{

    [SerializeField]
    private float powerupCd;

      public float PowerupCd
    {
        get { return powerupCd; }
        set { powerupCd = value; }
    }


    [SerializeField]
    private poweruptype powerUpType;
     
    public poweruptype PowerUpType
    {
        get { return powerUpType; }
        set { powerUpType = value; }
    }


    private void Loot(PlayerManager playerManager)
    {
        playerManager.activarBufo(powerUpType, powerupCd);
        playerManager.inventory["PowerUps"]++;
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