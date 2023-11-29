using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public Component doorCollider;

    protected override void Interaction()
    {
        Debug.Log("Picked up Key");

        AudioSource.PlayClipAtPoint(keysound, gameObject.transform.position);
        doorCollider.GetComponent<BoxCollider>().enabled = true;
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }

}
