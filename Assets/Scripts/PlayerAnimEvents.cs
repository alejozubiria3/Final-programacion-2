using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    PlayerManager _pMang;
    PlayerMovement player;
    [SerializeField] private GameObject sword, swordCollider;
    public CapsuleCollider attackCollider;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        _pMang = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MeleeAttackAnim(string param)
    {
        if (param == "KatMelee")
        {
            ActivateSword();
        }
        else
        {
            DeactivateSword();
        }
    }

    public void ActivateSword()
    {
        sword.SetActive(true);
    }

    public void DeactivateSword()
    {
        sword.SetActive(false);
    }

    public void SwordCollider(string param1)
    {
        if (param1 == "activateCollider")
        {
            ActivateCollider();
        }
        else if (param1 == "deactivateCollider")
        {
            DeactivateCollider();
        }
    }

    public void ActivateCollider()
    {
        swordCollider.SetActive(true);
    }

    public void DeactivateCollider()
    {
        swordCollider.SetActive(false);
    }

    public void Invincibility() 
    {
        attackCollider.enabled = false;
        player.moveSpeed = 15f;
    }

    public void DisableInvincibility() 
    {
        attackCollider.enabled = true;
        player.moveSpeed = 7.5f;
    }

    public void GameOver()
    {
        _pMang.Die();
    }

    //public void SpitAcid()
    //{
    //    acidParticle.SetActive(true);
    //}

    //public void StopSpitting()
    //{
    //    acidParticle.SetActive(false);
    //}
}
