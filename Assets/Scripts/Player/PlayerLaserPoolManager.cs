using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserPoolManager : MonoBehaviour
{

    [Header("Player Laser Pool Manager Config")]
    public static PlayerLaserPoolManager instance;

    [SerializeField] private GameObject bullet;
    private List<GameObject> pooledBullets = new List<GameObject>();
    private int amountToPool = 20;
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
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    // Retrieve player laser from pool
    public GameObject GetPooledObject()
    {
        foreach (GameObject laser in pooledBullets) 
        {
            if (!laser.activeInHierarchy)
            {
                return laser;
            }
        }

        // Expand pool is necessary
        if (expandPool)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledBullets.Add(obj);
            return obj;
        }

        return null;
    }
}
