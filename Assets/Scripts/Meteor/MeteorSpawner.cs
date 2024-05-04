using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [Header("Meteor Spawner Config")]
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float spawnInterval = 5.0f;
    [SerializeField] private Vector2 spawnPosition = new Vector2(-10, -2.5f);
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnMeteor());
    }

    // Spawn random meteor
    IEnumerator SpawnMeteor()
    {
        while (gameManager.isGameRunning)
        {
            int index = Random.Range(0, meteors.Length);
            Vector3 meteorPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
            Instantiate(meteors[index], meteorPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
