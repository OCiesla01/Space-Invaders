using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject enemyLaser;
    public float minTimeToShoot;
    public float maxTimeToShoot;

    private WaveSpawner waveSpawner;
    private GameManager gameManager;

    void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(ShootingRoutine());
    }

    IEnumerator ShootingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToShoot, maxTimeToShoot));
            Shoot();
        }
    }

    private void Shoot()
    {
        if (waveSpawner.isWaveSpawned && gameManager.isGameRunning)
        {
            GameObject laser = EnemyLaserPoolManager.instance.GetPooledObject();

            if (laser != null)
            {
                laser.transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                laser.transform.rotation = Quaternion.identity;

                Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                }

                laser.SetActive(true);
            }
        }
    }
}
