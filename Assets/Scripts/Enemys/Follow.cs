using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform enemigo;
    public Transform player;
    public float Velocidad;
    public float attackDistance;
    private bool _activo;
    private Vector3 _playerPosicion;
    private bool _isAttacking = false;


    public Animator animator;

    private void Update()
    {
        /*
        if (animator.GetFloat("health") <= 0) 
        {
            Destroy(GetComponent<Follow>());
        }
        */

        if (animator.GetBool("_isAttacking")) 
        {
            _isAttacking = true;    
        }

        _playerPosicion = new Vector3(player.position.x, enemigo.position.y, player.position.z);

        if (!_isAttacking)
        {
            if (_activo == true)
            {
                animator.SetBool("isMoving", true);
                enemigo.transform.position = Vector3.MoveTowards(transform.position, player.position, Velocidad * Time.deltaTime);
            }

        }
        else 
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(2.5f);
        _isAttacking = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _activo = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _activo = false;
            animator.SetBool("isMoving", false);
        }
    }

}
