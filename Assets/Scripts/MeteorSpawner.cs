using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public GameObject[] meteors;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnMeteor());
    }

    IEnumerator SpawnMeteor()
    {
        while (gameManager.isGameRunning)
        {
            int index = Random.Range(0, meteors.Length);
            Vector3 meteorPosition = new Vector3(-10, -2.5f, 0);
            Instantiate(meteors[index], meteorPosition, Quaternion.identity);

            yield return new WaitForSeconds(5);
        }
    }
}
