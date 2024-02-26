using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : Interactable
{

    [SerializeField] GameObject winMenu;

    protected override void Interaction()
    {
        if (myPlayer.inventory["Objectives"] >= 10) 
        {
            winMenu.SetActive(true);
            Time.timeScale = 0f;
            Destroy(transform.parent.gameObject);
        }
    }

}
