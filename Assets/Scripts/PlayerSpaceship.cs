using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5.0f;

    private float bottomBound = -4.3f;
    private float topBound = -2.5f;
    private float sideBound = 8.0f;

    private float horizontalInput;
    private float verticalInput;
    private Vector2 moveDirection;

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
        LimitPlayerMove();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        PlayerInput();

        moveDirection = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        transform.Translate(moveDirection);
    }

    private void LimitPlayerMove()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -sideBound, sideBound),
            Mathf.Clamp(transform.position.y, bottomBound, topBound)
        );
    }
}
