using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserPoolManager : MonoBehaviour
{

    public static PlayerLaserPoolManager instance;

    [SerializeField] private GameObject bullet;
    private List<GameObject> pooledBullets = new List<GameObject>();
    private int amountToPool = 20;

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
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBullets.Count; ++i)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        return null;
    }
}
