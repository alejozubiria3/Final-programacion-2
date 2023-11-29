using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract  class Zombie: MonoBehaviour,IDamagable
    

{
    [SerializeField] protected float hpMax;
    [SerializeField] protected float hp;
    [SerializeField] protected NavMeshAgent agent;
    protected bool _isAttacking;
    [SerializeField] protected float _attackCooldown;
    [SerializeField] protected  Animator zombieAnimator;
    
    
    
    protected abstract void Attack();

    protected abstract void Move();

    protected abstract void Death();

    protected virtual void Start()


    {


        hp = hpMax;


    }






    public void TakeDamage(float damage)
    {

        if (hp>0)
        {

            hp -= damage;
            if (hp<=0)
            {

                zombieAnimator.SetFloat("health", 0);
                Destroy(gameObject.GetComponent<Follow>());

            }

        }



    }
}