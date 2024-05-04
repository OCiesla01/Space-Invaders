using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;

public class PlayerLaserScript : MonoBehaviour
{

    [Header("Player Laser Config")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float disableZone = 6.5f;

    private GameManager gameManager;
    private WaveSpawner waveSpawner;
    private PlayerSpaceship playerSpaceship;
    private EnemyController enemyController;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
        enemyController = GameObject.Find("Wave").GetComponent<EnemyController>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        DisableBullet();
    }

    // Unactivate player laser if out of bounds
    private void DisableBullet()
    {
        if (transform.position.y >= disableZone)
        {
            gameObject.SetActive(false);
        }
    }

    // Handle player laser collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();

            AudioManager.instance.PlaySpaceshipExplosion();
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            gameManager.AddScore(enemyScript.GetPointValue());
            waveSpawner.enemiesInWave -= 1;
        }

        // collision with meteor
        if (collision.gameObject.CompareTag("Meteor"))
        {
            AudioManager.instance.PlayMeteorShot();
            gameObject.SetActive(false);
        }

        // collisions with different bonuses
        if (collision.gameObject.CompareTag("SpeedBonus"))
        {
            AudioManager.instance.PlayBonusPickup();
            CoroutineManager.instance.StartBonusCoroutine(GiveAndTakeSpeedBonus());

            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("SlowBonus"))
        {
            AudioManager.instance.PlayBonusPickup();
            CoroutineManager.instance.StartBonusCoroutine(GiveAndTakeSlowBonus());

            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("HealthBonus"))
        {
            AudioManager.instance.PlayBonusPickup();
            playerSpaceship.playerLives += 1;
            gameManager.UpdatePlayerLivesDisplay();

            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("ShieldBonus"))
        {
            AudioManager.instance.PlayBonusPickup();
            playerSpaceship.ActivateShield();

            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }

    // Handle speed bonus working time
    IEnumerator GiveAndTakeSpeedBonus()
    {
        playerSpaceship.moveSpeed *= 2;

        yield return new WaitForSeconds(5);

        playerSpaceship.moveSpeed /= 2;
    }

    // Handle slow bonus working time
    IEnumerator GiveAndTakeSlowBonus()
    {
        enemyController.speed /= 2;

        yield return new WaitForSeconds(5);

        enemyController.speed *= 2;
    }
}
