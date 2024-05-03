using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
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
            transform.Translate(Vector3.right * GetRandomBonusSpeed() * Time.deltaTime);
        }

        if (gameObject.transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    private float GetRandomBonusSpeed()
    {
        return Random.Range(2, 6);
    }
}
