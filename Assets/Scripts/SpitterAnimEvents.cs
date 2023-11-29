using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterAnimEvents : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem acidParticle;
    [SerializeField]
    private BoxCollider acidCollider;


    public void SpitAcid()
    {
        acidParticle.Play();
    }

    public void StopSpitting()
    {
        acidParticle.Stop();
    }

    public void ActivateAcid()
    {
        acidCollider.enabled = true;
    }

    public void DisableAcid()
    {
        acidCollider.enabled = false;
    }
}
