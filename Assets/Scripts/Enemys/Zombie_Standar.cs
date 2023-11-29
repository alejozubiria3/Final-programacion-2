using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie_Standar : Zombie
{
    public GameObject player;
    public Transform jugador;
    public PlayerManager myPlayer;
    public float damage;
    public float attackDistance;
    public float rotationSpeed;
    
  
    protected override void Move()
    {
    
    }

    protected override void Attack()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            var damagable = player.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(damage);
            }
        }
    }

   
    public void Die()
    {
        Destroy(gameObject);

        Destroy(gameObject);
        Debug.Log("Zombie Muerto");

    }

    protected override void Death()
    {
        
    }

    //public void DeathForEvent()
    //{
    //    Death();
    //}


    private IEnumerator Attacking()
    {
        zombieAnimator.SetBool("_isAttacking", true);
        yield return new WaitForSeconds(0.25f);
        zombieAnimator.SetBool("_isAttacking", false);
    }

    private void Update()
    {

        Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);

        CheckDistance();

        

        
    }

    private void CheckDistance() 
    {
        if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            StartCoroutine(Attacking());
        }

        Vector3 relativePos = jugador.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

    }

    
}
