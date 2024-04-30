using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 4.0f;

    private int playerLives = 3;

    private float sideBound = 8.0f;
    private float playerYPosition = -4.0f;

    private float horizontalInput;
    private Vector2 moveDirection;

    private WaveSpawner waveSpawner;
    private GameManager gameManager;

    private void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (waveSpawner.isWaveSpawned)
        {
            MovePlayer();
            LimitPlayerMove();
        }
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        PlayerInput();

        moveDirection = new Vector2(horizontalInput, 0) * moveSpeed * Time.deltaTime;

        transform.Translate(moveDirection);
    }

    private void LimitPlayerMove()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -sideBound, sideBound),
            playerYPosition
        );
    }

    public void HandlePlayerLives()
    {
        if (playerLives > 0)
        {
            playerLives -= 1;
        }
        else
        {
            Destroy(gameObject);
            gameManager.isGameRunning = false;
        }
    }
}
