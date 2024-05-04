using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{

    [Header("Player Spaceship Movement Config")]
    public float moveSpeed = 4.0f;
    public int playerLives = 3;
    private bool hasShield = false;

    [SerializeField] private float sideBound = 8.0f;
    [SerializeField] private float playerYPosition = -4.0f;
    [SerializeField] private Vector3 startingPosition = new Vector3(0, -4, 0);

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

    // Handle player input
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    // Move player based on input and speed
    private void MovePlayer()
    {
        PlayerInput();

        moveDirection = new Vector2(horizontalInput, 0) * moveSpeed * Time.deltaTime;

        transform.Translate(moveDirection);
    }

    // Limit player movement
    private void LimitPlayerMove()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -sideBound, sideBound),
            playerYPosition
        );
    }

    // Manage player lives
    public void HandlePlayerLives()
    {
        if (hasShield)
        {
            AudioManager.instance.PlayShieldDown();
            hasShield = false;
        }
        else
        {
            AudioManager.instance.PlaySpaceshipExplosion();
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
    }

    // Reset player position
    public void ResetPlayersPosition()
    {
        gameObject.transform.position = startingPosition;
    }

    // Activate player shield (from bonuses)
    public void ActivateShield()
    {
        hasShield = true;
    }
}
