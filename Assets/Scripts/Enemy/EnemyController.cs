using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Wave Config")]
    public float speed = 0.5f;
    [SerializeField] private bool movingRight = true;
    [SerializeField] private float bounds = 2.4f;
    [SerializeField] private float stepDown = .75f;

    private WaveSpawner waveSpawner;
    private GameManager gameManager;

    private float lastDescentTime = 0f;
    private float descentCooldown = 0.5f;

    private void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (ShouldMove())
        {
            Move();
            CheckBoundsAndAdjust();
        }
    }

    // Check if enemy should move
    private bool ShouldMove()
    {
        return waveSpawner.isWaveSpawned && gameManager.isGameRunning;
    }

    // Move enemy
    private void Move()
    {
        float horizontalMovement = movingRight ? speed : -speed;
        transform.Translate(Vector2.right * horizontalMovement * Time.deltaTime);
    }

    // Check bounds to move enemy lower
    private void CheckBoundsAndAdjust()
    {
        if (Mathf.Abs(transform.position.x) > bounds)
        {
            DescendWave();
        }
    }

    // Move wave of enemies lower
    private void DescendWave()
    {
        if (Time.time - lastDescentTime < descentCooldown) { return; }

        movingRight = !movingRight;
        transform.position = new Vector2(transform.position.x, transform.position.y - stepDown);
        lastDescentTime = Time.time;
    }
}
