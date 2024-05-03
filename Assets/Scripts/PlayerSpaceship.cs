using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{

    [Header("Player Movement")]
    public float moveSpeed = 4.0f;

    public int playerLives = 13;

    private float sideBound = 8.0f;
    private float playerYPosition = -4.0f;

    private float horizontalInput;
    private Vector2 moveDirection;

    private WaveSpawner waveSpawner;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (DataManager.instance != null && DataManager.instance.selectedSprite != null)
        {
            spriteRenderer.sprite = DataManager.instance.selectedSprite;
        }
        else
        {
            Debug.LogError("No sprite or DataManager found");
        }
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
        playerLives -= 1;

        if (playerLives > 0)
        {
            gameManager.UpdatePlayerLivesDisplay();
        }
        else
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    public void ResetPlayersPosition()
    {
        gameObject.transform.position = new Vector3(0, -4, 0);
    }

    public void ActivateShield()
    {
        Debug.Log("Shield Activated.");
    }
}
