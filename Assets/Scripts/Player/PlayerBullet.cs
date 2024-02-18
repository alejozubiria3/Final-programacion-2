using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    
    struct BulletData
    {
        public float damage;
        public float speed;
        public float maxRange;
        
    }

    
    private BulletData bulletData;

    
    void Start()
    {
        bulletData.damage = 10f;
        bulletData.speed = 20f;
        bulletData.maxRange = 50f;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
        }
    }
}
