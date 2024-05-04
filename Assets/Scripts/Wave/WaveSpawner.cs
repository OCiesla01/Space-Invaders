using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [Header("Wave Spawner Config")]
    [SerializeField] private GameObject[] rowPrefabs;
    [SerializeField] private float initialYSpawnPosition = 0;
    [SerializeField] private float delayBetweenSpawns = 0.75f;
    [SerializeField] private GameObject waveParent;

    public int enemiesInWave;
    public bool isWaveSpawned = false;
    private float ySpawnPosition;

    private PlayerSpaceship playerSpaceship;
    private GameManager gameManager;

    void Start()
    {
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        ResetWaveSpawner();
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

    // Reset enemies in wave and wave's position
    private void ResetWaveSpawner()
    {
        enemiesInWave = 0;
        ySpawnPosition = initialYSpawnPosition;
        isWaveSpawned = false;
    }

    // Check whether to spawn new wave
    private void SpawnNewWave()
    {
        enemiesInWave = 0;

        if (enemiesInWave <= 0)
        {
            StartCoroutine(SpawnWave());
        }
    }

    // Spawn new wave
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

    // Reset wave position
    private void ResetWavePosition()
    {
        waveParent.transform.position = Vector2.zero;
        ySpawnPosition = initialYSpawnPosition;
    }

    // Add defeated wave to score
    private void EnemyWaveDefeated()
    {
        gameManager.AddWaveDefeated();
    }
}
