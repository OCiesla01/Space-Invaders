using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

    public GameObject[] bonuses;
    private float minSpawnY = -1.0f;
    private float maxSpawnY = 4.0f;
    private float spawnX = -10.0f;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnBonus());

    }

    IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(5);

        while (gameManager.isGameRunning)
        {
            int index = Random.Range(0, bonuses.Length);
            float spawnY = Random.Range(minSpawnY, maxSpawnY);
            Vector3 bonusPosition = new Vector3(spawnX, spawnY, 0);
            Instantiate(bonuses[index], bonusPosition, Quaternion.identity);

            yield return new WaitForSeconds(10);
        }
    }
}
