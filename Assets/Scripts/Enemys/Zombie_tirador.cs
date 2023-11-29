using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_tirador : Zombie

{
   
    [SerializeField] Transform _spawnpoint;
    private GameObject _target;
    private bool _intrigger;
    public float attackDistance;
    public LayerMask capaDelJugador;
    public Transform jugador;

    protected override void Attack()
    {

        PoolsHolder.Instance.SelectPool(1).SpawnBullet(_spawnpoint.position, transform.forward, this.gameObject);

    }
    IEnumerator Attackroutine()
    {
        
        zombieAnimator.SetBool("_isAttacking", true);
        yield return new WaitForSeconds(_attackCooldown);
        zombieAnimator.SetBool("_isAttacking", false);

    }

    protected override void Death()
    {
        Destroy(gameObject);
        Debug.Log("Spitter muerto");
    }

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }

   
    

    // Update is called once per frame
    void Update()
    {

        Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        transform.LookAt(posJugador);

        if (Vector3.Distance(transform.position, jugador.position) <= attackDistance)
        {
            StartCoroutine(Attackroutine());

        }
        if (_intrigger && _target)
        {
            StartCoroutine(Attackroutine());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.gameObject;
            _intrigger = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            _target = null;
            _intrigger = false;


        }

    }
}
