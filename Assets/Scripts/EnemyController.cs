using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Wave")]
    [SerializeField] private float speed = 0.5f;

    private bool movingRight = true;
    private float bounds = 2.4f;
    private float stepDown = .75f;

    private WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
    }

    void Update()
    {
        if (waveSpawner.isWaveSpawned)
        {
            if (movingRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }

            if (transform.position.x > bounds || transform.position.x < -bounds)
            {
                DescendWave();
            }
        }
    }

    private void DescendWave()
    {
        movingRight = !movingRight;
        transform.position = new Vector2(transform.position.x, transform.position.y - stepDown);
    }
}
