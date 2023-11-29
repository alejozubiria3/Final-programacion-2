using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerPool : MonoBehaviour
{
    public Bullet bullet;

    protected ObjectPool<Bullet> pool;

    protected Bullet _currentBullet;

    public Bullet GetCurrentBullet => _currentBullet;

    public ObjectPool<Bullet> GetPool
    {
        get
        {
            return pool;
        }
    }

    public void OnStart()
    {
        pool = new ObjectPool<Bullet>(BulletReturn, Bullet.TurnOn, Bullet.TurnOff, 10);
    }

    public virtual void SpawnBullet( Vector3 spawnPoint, Vector3 dir, GameObject owner)
    {
        var b = pool.GetObject();
        b.OnInstantiatePool(pool, spawnPoint, dir);
       

        _currentBullet = b;
    }

    public Bullet BulletReturn()
    {
        return Instantiate(bullet);
    }
}