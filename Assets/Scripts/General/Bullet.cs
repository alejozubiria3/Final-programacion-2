using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet  : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _maxDistance;
    [SerializeField] protected float _damage;
    protected Vector3 _direction;
    protected float _currentDistance;
    protected ObjectPool<Bullet> _mPool;

    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        _currentDistance += _speed * Time.deltaTime;
        if (_currentDistance>= _maxDistance)
        {
            Destroy(gameObject);
        }



        

    }

    public static void TurnOn(Bullet bullet)
    {

        bullet.Reset();
        bullet.gameObject.SetActive(true);
        

    }
    public  static void TurnOff(Bullet bullet)
    {

        bullet.gameObject.SetActive(false);

    }

    protected void Reset()
    {
        _currentDistance = 0;



    }



    public virtual void OnInstantiatePool(ObjectPool<Bullet> pool, Vector3 spawnPos, Vector3 dir)
    {
       
        _mPool = pool;
        transform.position = spawnPos;

        transform.forward = dir;

        _direction   = dir;
    }



    void OnCollision()
    {

        if (_mPool!=null)
        {
            _mPool.ReturnObject(this);
        }


    }


    protected virtual void OnTriggerEnter(Collider other) {

        var damagable = other.GetComponent<IDamagable>();
        if (damagable!=null)

        {
            damagable.TakeDamage(_damage);
            OnCollision();


        }
    
    
    
    
    }

    
        



    



}
