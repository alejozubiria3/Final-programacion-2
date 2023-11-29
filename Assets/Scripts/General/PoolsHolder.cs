using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsHolder : MonoBehaviour
{
    public static PoolsHolder Instance;
    [SerializeField] private SpawnerPool _enemySpawnerPool;
    [SerializeField] private SpawnerPool _playerSpawnerPool;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(this);
    }

    public SpawnerPool SelectPool(int n = 0)
    {
        switch (n)
        {
            case 0:
                return _playerSpawnerPool;
            case 1:
                return _enemySpawnerPool;
            default:
                return default;
        }
    }
}
