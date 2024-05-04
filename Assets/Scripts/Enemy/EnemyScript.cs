using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [Header("Enemy Config")]
    [SerializeField] private int pointValue;
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private float minTimeToShoot;
    [SerializeField] private float maxTimeToShoot;
    [SerializeField] private float laserOffset;

    private float playerY = -4.0f;

    private WaveSpawner waveSpawner;
    private GameManager gameManager;

    void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(ShootingRoutine());
    }

    void Update()
    {
        YPositionBelowPlayer();
    }

    // Automatically shoot laser with specified interval
    IEnumerator ShootingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToShoot, maxTimeToShoot));
            Shoot();
        }
    }

    // Enemy laser shoot method
    private void Shoot()
    {
        if (waveSpawner.isWaveSpawned && gameManager.isGameRunning)
        {
            GameObject laser = EnemyLaserPoolManager.instance.GetPooledObject();

            if (laser != null)
            {
                laser.transform.position = new Vector2(transform.position.x, transform.position.y - laserOffset);
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

    // End the game if enemy below or at player Y position
    public void YPositionBelowPlayer()
    {
        if (transform.position.y <= playerY)
        {
            gameManager.GameOver();
        }
    }

    // Get point value of enemy
    public int GetPointValue()
    {
        return pointValue;
    }
}
