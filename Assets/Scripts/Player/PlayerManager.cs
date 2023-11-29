using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IDamagable
{

    public int objectives = 0;
    public float maxHealth = 10;
    public float health = 10;

    public string fireButton = "Fire1";
    [SerializeField]
    private float _attackCoolDown;

    private bool _canAttack;

    public UI healthBar;
    public GameObject gameOverScreen;

    public AudioSource audioSource;
    public AudioClip gunSound;
    public AudioClip hurt;
   

    public Animator animator;

    public void activarBufo(poweruptype poweruptype, float cd)

    {

        StartCoroutine(rutinaDeBufo(poweruptype,cd  ));


    }

    private IEnumerator rutinaDeBufo(poweruptype poweruptype, float cd)
    {
        _attackCoolDown = 0.3f;
        yield return new WaitForSeconds(cd);
        _attackCoolDown = 1;

    }
        

    void Start ()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _canAttack = true;
        
    }

    void Attack()
    {
        
        if (Input.GetButtonDown(fireButton))
        {
            if (_canAttack)
            {
             
                StartCoroutine("Shooting");
                _canAttack = false;
               
                

            }

        }
    }

    public void Die() 
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }


    
    


    void Update()
    {
        healthBar.SetHealth(health);

        Attack();
    }


    [Header("Pistol")]

    [SerializeField]
    private     Transform   _pistolBulletSpawnPoint;
    private     RaycastHit  _pistolRaycastHit;
    [SerializeField]
    private     float       _maxBulletRange;
    [SerializeField]
    private     LayerMask   _pistolRaycastMask;
    [SerializeField]
    private GameObject      _impactParticles;
    


    public void SimulatePistolBullet()
    {
        if (Physics.Raycast(_pistolBulletSpawnPoint.position, _pistolBulletSpawnPoint.forward, out _pistolRaycastHit, _maxBulletRange, _pistolRaycastMask.value))
        {
            //Debug.Log(pistolRaycastHit.transform.name);         //cuando le pega, le pide el nombre.
            GameObject spawnedParticles = Instantiate(_impactParticles, _pistolRaycastHit.point, Quaternion.identity);
            spawnedParticles.transform.up = _pistolRaycastHit.normal;
  
        }
    }


    private IEnumerator Shooting()
    {
        animator.SetBool("_isShooting", true);
        SimulatePistolBullet();

        PoolsHolder.Instance.SelectPool().SpawnBullet(_pistolBulletSpawnPoint.position, _pistolBulletSpawnPoint.forward, this.gameObject);
        audioSource.PlayOneShot(gunSound);
        yield return new WaitForSeconds(_attackCoolDown);
        animator.SetBool("_isShooting", false);
        _canAttack = true;

    }
    

    public void TakeDamage(float damage)
    {
        if (health>0)
        {
            
            health -= damage;
            healthBar.SetHealth(health);
            audioSource.PlayOneShot(hurt);

            if (health<=0)
            {
                Debug.Log("moriste");
                animator.SetBool("_isAlive", false);

            }
        }
        
    }

   
}
