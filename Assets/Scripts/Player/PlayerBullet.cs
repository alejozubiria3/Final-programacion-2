using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{


    protected override void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.CompareTag("Player"))
        {

            base.OnTriggerEnter(other);

        }



    }

}
