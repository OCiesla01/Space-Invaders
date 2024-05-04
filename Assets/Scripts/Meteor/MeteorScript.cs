using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    [Header("Meteor Config")]
    [SerializeField] private float minMeteorSpeed = 1.0f;
    [SerializeField] private float maxMeteorSpeed = 4.0f;
    [SerializeField] private float destroyZone = 10.0f;
    private float meteorSpeed;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        meteorSpeed = GetRandomMeteorSpeed();
    }

    void Update()
    {
        if (gameManager.isGameRunning)
        {
            transform.Translate(Vector3.right * meteorSpeed * Time.deltaTime);
        }

        if (gameObject.transform.position.x > destroyZone)
        {
            Destroy(gameObject);
        }
    }

    // Get meteor random speed
    private float GetRandomMeteorSpeed()
    {
        return Random.Range(minMeteorSpeed, maxMeteorSpeed);
    }
}
