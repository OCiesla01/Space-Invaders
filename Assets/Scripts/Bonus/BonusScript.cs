using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{

    [Header("Bonus Config")]
    private GameManager gameManager;
    [SerializeField] private float destroyZone = 10.0f;

    private float bonusSpeed;
    private Transform myTransform;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        myTransform = transform;
        bonusSpeed = GetRandomBonusSpeed();
    }

    void Update()
    {
        if (!gameManager.isGameRunning)
        {
            return;
        }

        MoveBonus();
        CheckBoundary();
    }

    // Get random speed for bonus movement
    private float GetRandomBonusSpeed()
    {
        return Random.Range(2, 6);
    }

    // Move bonus through the screen
    private void MoveBonus()
    {
        myTransform.Translate(Vector3.right * bonusSpeed * Time.deltaTime);
    }

    // Destroy bonus if out of bounds
    private void CheckBoundary()
    {
        if (myTransform.position.x > destroyZone)
        {
            Destroy(gameObject);
        }
    }
}
