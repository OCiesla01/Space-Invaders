using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

    [Header("Bonus Spawner Config")]
    [SerializeField] private GameObject[] bonuses;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float initialDelay = 5.0f;
    [SerializeField] private float delayBetweenSpawns = 10.0f;

    private float minSpawnY = -1.0f;
    private float maxSpawnY = 4.0f;
    private float spawnX = -10.0f;


    void Start()
    {
        StartCoroutine(SpawnBonus());
    }

    // Spawn random bonus
    IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(initialDelay);

        while (gameManager.isGameRunning)
        {
            if (bonuses.Length > 0)
            {
                int index = Random.Range(0, bonuses.Length);
                float spawnY = Random.Range(minSpawnY, maxSpawnY);
                Vector3 bonusPosition = new Vector3(spawnX, spawnY, 0);
                Instantiate(bonuses[index], bonusPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }
}
