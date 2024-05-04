using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    [Header("Enemy Laser Config")]
    [SerializeField] private float speed = 7.5f;
    private float disableZone = -6.0f;

    private PlayerSpaceship playerSpaceship;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Start()
    {
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
    }

    void Update()
    {
        myTransform.Translate(Vector2.down * speed * Time.deltaTime);

        if (myTransform.position.y <= disableZone)
        {
            gameObject.SetActive(false);
        }
    }

    // Detect enemy laser collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision with player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerSpaceship.HandlePlayerLives();
            gameObject.SetActive(false);
        }

        // collision with meteor
        else if (collision.gameObject.CompareTag("Meteor"))
        {
            AudioManager.instance.PlayMeteorShot();
            gameObject.SetActive(false);
        }
    }
}
