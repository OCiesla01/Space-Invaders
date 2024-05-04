using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{

    [Header("Coroutine Manager Config")]
    public static CoroutineManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start specified coroutine
    public void StartBonusCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
