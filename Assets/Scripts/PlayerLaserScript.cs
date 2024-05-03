using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;

public class PlayerLaserScript : MonoBehaviour
{

    [Header("Player Laser")]
    [SerializeField] private float speed = 10.0f;
    private float disableZone = 6.5f;

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
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            gameManager.AddScore(enemyScript.value);
            waveSpawner.enemiesInWave -= 1;
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("SpeedBonus"))
        {
            Debug.Log("Speed Bonus");
            CoroutineManager.instance.StartBonusCoroutine(GiveAndTakeSpeedBonus());

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("SlowBonus"))
        {
            Debug.Log("Slow Bonus");
            CoroutineManager.instance.StartBonusCoroutine(GiveAndTakeSlowBonus());

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("HealthBonus"))
        {
            Debug.Log("Health bonus");
            playerSpaceship.playerLives += 1;
            gameManager.UpdatePlayerLivesDisplay();

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ShieldBonus"))
        {
            playerSpaceship.ActivateShield();

            Destroy(collision.gameObject);
        }
    }

    IEnumerator GiveAndTakeSpeedBonus()
    {
        playerSpaceship.moveSpeed *= 2;
        Debug.Log("Player Speed start: " +  playerSpaceship.moveSpeed);

        yield return new WaitForSeconds(5);

        playerSpaceship.moveSpeed /= 2;
        Debug.Log("Player Speed end: " + playerSpaceship.moveSpeed);
    }

    IEnumerator GiveAndTakeSlowBonus()
    {
        enemyController.speed /= 2;
        Debug.Log("Enemy Speed start: " + enemyController.speed);

        yield return new WaitForSeconds(5);

        enemyController.speed *= 2;
        Debug.Log("Enemy Speed end: " + enemyController.speed);
    }
}
