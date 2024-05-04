using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserPoolManager : MonoBehaviour
{

    [Header("Enemy Laser Pool Manager Config")]
    public static EnemyLaserPoolManager instance;

    [SerializeField] private GameObject enemyLaser;
    private List<GameObject> pooledLasers = new List<GameObject>();
    [SerializeField] private int amountToPool = 40;
    [SerializeField] private bool expandPool = true;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; ++i)
        {
            GameObject obj = Instantiate(enemyLaser);
            obj.SetActive(false);
            pooledLasers.Add(obj);
        }
    }

    // Retrieve Enemy laser for pool
    public GameObject GetPooledObject()
    {
        foreach (GameObject laser in pooledLasers)
        {
            if (!laser.activeInHierarchy)
            {
                return laser;
            }
        }

        // expand pool if necessary
        if (expandPool)
        {
            GameObject obj = Instantiate(enemyLaser);
            obj.SetActive(false);
            pooledLasers.Add(obj);
            return obj;
        }

        return null;
    }
}
