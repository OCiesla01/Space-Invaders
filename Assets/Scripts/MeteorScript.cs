using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.isGameRunning)
        {
            transform.Translate(Vector3.right * GetRandomMeteorSpeed() * Time.deltaTime);
        }
    }

    private float GetRandomMeteorSpeed()
    {
        return Random.Range(1, 4);
    }
}
