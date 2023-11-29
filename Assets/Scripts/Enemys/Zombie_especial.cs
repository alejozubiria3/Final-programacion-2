using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_especial : Zombie
{
    public float attackDistance;
    public LayerMask capaDelJugador;
    public Transform jugador;

    public Animator TankAnimator;



    public float velocidad;
    bool estarAlerta;
    private static Vector3 position;


    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Death()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }


   



    // Update is called once per frame

    void Update()
    {


        if (Vector3.Distance(transform.position, jugador.position) <= attackDistance)
        {
            StartCoroutine("Attacking");
            Attack();




        }

    }


    private IEnumerator Attacking()
    {
        TankAnimator.SetBool("_isAttacking", true);
        yield return new WaitForSeconds(0.125f);
        TankAnimator.SetBool("_isAttacking", false);
    }
}