using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceOnSpawn : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigidbody;
    [SerializeField]
    private float forceToApply;

    void Start()
    {
        myRigidbody.AddForce(transform.up * forceToApply, ForceMode.Impulse);
    }
}


