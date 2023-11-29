using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Zombie
{
    public float damage;
    public Transform jugador;
    public PlayerManager myPlayer;
    public GameObject particle;
    public AudioSource audioSource;
    public GameObject model;
    public AudioClip sonido;
    public AudioClip hurt;


    private void FixedUpdate()
    {
        Death();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exploto");
            var damagable = myPlayer.GetComponent<IDamagable>();
            if (damagable != null)

            {

                damagable.TakeDamage(damage);
                StartCoroutine(Exploderoutine());

            }

            
        }




    }

    protected override void Move()
    {

    }
    protected override void Death()
    {
        if(hp <= 0)
        {
            StartCoroutine(Exploderoutine());
        }
        //Destroy(gameObject);
    }
    protected override void Attack()
    {

    }


    IEnumerator Exploderoutine()
    {
        model.SetActive(false);
        particle.SetActive(true);
        AudioSource.PlayClipAtPoint(sonido, gameObject.transform.position);
        AudioSource.PlayClipAtPoint(hurt, gameObject.transform.position);

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);

    }



    private void Update()
    {
        Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        transform.LookAt(posJugador);
    }
}
