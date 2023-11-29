using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetiveCounter : MonoBehaviour
{
    int objetive = 0;
    public Text counter;


    public void IncreaseObjetiveScore(int amount)
    {
        objetive += amount;
        counter.text = objetive + " / 10";
    }
}
