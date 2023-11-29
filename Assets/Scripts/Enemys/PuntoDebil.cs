using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDebil : MonoBehaviour, IDamagable

{
    public Zombie zombieTanque;



    public void TakeDamage(float damage)
    {

        zombieTanque.TakeDamage(damage * 1.5f);


    }

    
}
