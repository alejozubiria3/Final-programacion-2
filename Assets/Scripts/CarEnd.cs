using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnd : Interactable
{
    [SerializeField] GameObject winUi;

    protected override void Interaction()
    {
        Time.timeScale = 0f;
        winUi.SetActive(true);
    }
}
