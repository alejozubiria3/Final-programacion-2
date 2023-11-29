using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_melee : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _damage;
    private Vector3 _direction;
    private float _currentDistance;
    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        _currentDistance += _speed * Time.deltaTime;
        if (_currentDistance >= _maxDistance)
        {
            Destroy(gameObject);
        }
    }

    public Ataque_melee Shoot(Transform newdirection)
    {

        Vector3 dir = newdirection.position - transform.position;
        _direction = dir;
        transform.forward = _direction;
        return this;

    }

}
