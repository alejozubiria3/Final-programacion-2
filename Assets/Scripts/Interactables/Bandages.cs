using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandages : Interactable
{
    protected override void Interaction()
    {
        if (myPlayer.health < myPlayer.maxHealth)
        {
            Debug.Log("Picked up Bandage");

            myPlayer.inventory["Bandages"]++;

            AudioSource.PlayClipAtPoint(keysound, gameObject.transform.position);
            myPlayer.health = myPlayer.maxHealth;
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }

}
