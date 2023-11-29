using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public  float       delay;
    public  float       radioExplosion;
    public  float       explosionForce;
    public  GameObject  explotionEffect;






    float   _countdown;
    bool    _hasExploded = false;


    void Start()
    {
        _countdown = delay;                                                                         //una vez que aparece en escena, empieza cuenta regresiva
    }

       void Update()    
    {
        _countdown -= Time.deltaTime;                                                                   //si acabo la cuenta, y no exploto...
        if (_countdown <= 0f && !_hasExploded)
        {
            Explode();                                                                               //...llama a la funcion de explosion
            _hasExploded = true;                                                                     // cambia el bool, para que no explote mas.
        }

    }

    void Explode()
    {
        Instantiate(explotionEffect, transform.position, transform.rotation);                        //Instancia las particulas para dar efecto de explosion

        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);            //crea un array con todos los objetos dentro del radio de la explosion

        foreach (Collider nearbyObject in colliders)                                                //por cada objeto que se encuentre en el array...
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();                                 //busca el rigidBody..          
            if (rb != null)                                                                         //chequea si no es nulo..
            {
                rb.AddExplosionForce(explosionForce, transform.position, radioExplosion);           //le agrega el efecto de explosion a los RigidBodys que tenga en el radio.
                Debug.Log("le dio a " + nearbyObject.GetComponent(name));                           //printa el nombre / hay que cambiarlo porque haga danio
            }
        
        }
        //LLAMAR LA FUNCION TakeDamage()

        Destroy(gameObject);                                                        //Destruye la granada - falta que borre la particula que spawnea 
    }
}
