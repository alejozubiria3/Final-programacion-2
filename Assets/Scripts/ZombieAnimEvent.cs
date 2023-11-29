using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimEvent : MonoBehaviour
{
    [SerializeField] private ZombieNaza zombie;
    [SerializeField] private Zombie_Standar zombieTank;
    [SerializeField] private BoxCollider attackCollider;
    [SerializeField] private SphereCollider aoeAttack;

    private void Start()
    {
        //zombie = GetComponent<ZombieNaza>();
    }

    public void Die()
    {
        zombie.Die();
    }

    public void TankDie()
    {
        zombieTank.Die();
    }
    public void ActivateCollider()
    {
        attackCollider.enabled = true;
    }

    public void DisableCollider()
    {
        attackCollider.enabled = false;
    }

    public void ActivateAOE()
    {
        aoeAttack.enabled = true;
    }

    public void DisableAOE()
    {
        aoeAttack.enabled = false;
    }
}
