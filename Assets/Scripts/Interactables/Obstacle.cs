using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Interactable
{
    
    protected override void Interaction()
    {
        Debug.Log("Destroyed Obstacle");

        AudioSource.PlayClipAtPoint(keysound, gameObject.transform.position);
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }
}
