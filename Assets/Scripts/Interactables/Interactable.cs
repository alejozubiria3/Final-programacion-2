using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField] protected bool isInRange;
    [SerializeField] protected KeyCode interactKey;
    [SerializeField] protected PlayerManager myPlayer;
    [SerializeField] protected AudioSource source;
    [SerializeField] protected AudioClip keysound;

    protected virtual void Update() 
    {
        DestroyOnInteraction();
    }


    public void DestroyOnInteraction() 
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                Interaction();
                
            }
        }
    }

    protected abstract void Interaction();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
