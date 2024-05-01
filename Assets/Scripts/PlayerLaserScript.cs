using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerLaserScript : MonoBehaviour
{

    [Header("Player Laser")]
    [SerializeField] private float speed = 10.0f;
    private float disableZone = 6.5f;
    private GameManager gameManager;
    private WaveSpawner waveSpawner;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        DisableBullet();
    }

    private void DisableBullet()
    {
        if (transform.position.y >= disableZone)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            gameManager.AddScore(1);
            waveSpawner.enemiesInWave -= 1;
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            gameObject.SetActive(false);
        }
    }
}
