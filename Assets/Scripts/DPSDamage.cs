using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSDamage : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float _dpsDamage;

    //private void OnTriggerEnter(Collider other)
    //{
    //    var damageable = other.GetComponent<IDamagable>();
    //    if (damageable != null)
    //    {
    //        damageable.TakeDamage(_dpsDamage);

    //    }
    //}
    private void OnTriggerStay(Collider other)
    {
        var damageable = other.GetComponent<IDamagable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_dpsDamage);

        }
    }
}
