using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Wave")]
    [SerializeField] private float speed = 2.0f;

    private bool movingRight = true;
    private float bounds = 4.0f;
    private float stepDown = 1.0f;

    void Update()
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

    private void DescendWave()
    {
        movingRight = !movingRight;
        transform.position = new Vector2(transform.position.x, transform.position.y - stepDown);
    }
}
