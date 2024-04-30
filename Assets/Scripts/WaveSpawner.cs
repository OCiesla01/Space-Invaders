using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObject[] rowPrefabs;
    public float ySpawnPosition;
    public float delayBetweenSpawns = 0.75f;
    public bool isWaveSpawned = false;
    public GameObject waveParent;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        foreach (GameObject rowPrefab in rowPrefabs) 
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, ySpawnPosition);
            GameObject row = Instantiate(rowPrefab, spawnPosition, Quaternion.identity);
            row.transform.SetParent(waveParent.transform, false);
            ySpawnPosition += 1.0f;

            yield return new WaitForSeconds(delayBetweenSpawns);
        }

        isWaveSpawned = true;
    }
}
