using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
    
{
    public PlayerManager myPlayer;
    public static UI Instance;
    public Slider slider;   



    private void Awake()
    {

        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);

        }

    }

    public void SetMaxHealth(float health)
    {
        slider.value = health / 100;
    }
    
    public void SetHealth(float health)
    {

        slider.value = health / 100;

    }





}
