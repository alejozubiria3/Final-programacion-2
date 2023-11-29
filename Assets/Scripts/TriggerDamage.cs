using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour

{
    public float _attackDamage;
    
    
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamagable>();
        if (damageable!=null)
        {
            damageable.TakeDamage(_attackDamage);
            
        }

    }


}
