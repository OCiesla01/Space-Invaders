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
    public int enemiesInWave;

    private PlayerSpaceship playerSpaceship;
    private GameManager gameManager;

    void Start()
    {
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemiesInWave = 0;
        SpawnNewWave();
    }

    private void Update()
    {
        if (enemiesInWave <= 0 && isWaveSpawned)
        {
            EnemyWaveDefeated();
            SpawnNewWave();
        }
    }

    public void SpawnNewWave()
    {
        enemiesInWave = 0;

        if (enemiesInWave <= 0)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        ResetWavePosition();
        playerSpaceship.ResetPlayersPosition();

        isWaveSpawned = false;
        foreach (GameObject rowPrefab in rowPrefabs) 
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, ySpawnPosition);
            GameObject row = Instantiate(rowPrefab, spawnPosition, Quaternion.identity);
            row.transform.SetParent(waveParent.transform, false);
            ySpawnPosition += 1.0f;

            yield return new WaitForSeconds(delayBetweenSpawns);
        }

        isWaveSpawned = true;
        enemiesInWave = 45;
    }

    public void ResetWavePosition()
    {
        waveParent.transform.position = Vector2.zero;
        ySpawnPosition = 0;
    }

    public void EnemyWaveDefeated()
    {
        gameManager.AddWaveDefeated();
    }
}
