using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    [Header("Enemy Laser")]
    [SerializeField] private float speed = 7.5f;
    private float disableZone = -6.0f;

    private PlayerSpaceship playerSpaceship;

    private void Start()
    {
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        DisableLaser();
    }

    private void DisableLaser()
    {
        if (transform.position.y <= disableZone)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            playerSpaceship.HandlePlayerLives();
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            Debug.Log("Collision with meteor");
            gameObject.SetActive(false);
        }
    }
}
