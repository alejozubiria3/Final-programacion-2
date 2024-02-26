using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : Interactable
{

    private int _value = 1;

    protected override void Interaction()
    {
        Debug.Log("Picked up Objective");

        myPlayer.inventory["Objectives"]++;

        AudioSource.PlayClipAtPoint(keysound, gameObject.transform.position);
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
        ObjetiveCounter objetiveTracker = myPlayer.GetComponent<ObjetiveCounter>();
        objetiveTracker.IncreaseObjetiveScore(_value);
    }
}
