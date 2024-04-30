using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserPoolManager : MonoBehaviour
{

    public static EnemyLaserPoolManager instance;

    [SerializeField] private GameObject enemyLaser;
    private List<GameObject> pooledLasers = new List<GameObject>();
    private int amountToPool = 40;

    private void Awake()
    {
        if (instance == null)
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

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledLasers.Count; ++i)
        {
            if (!pooledLasers[i].activeInHierarchy)
            {
                return pooledLasers[i];
            }
        }

        return null;
    }
}
