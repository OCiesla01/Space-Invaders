using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    [Header("Enemy Laser")]
    [SerializeField] private float speed = 7.5f;
    private float disableZone = -6.0f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        DisableLaser();
    }

    private void DisableLaser()
    {
        if (transform.position.y <= disableZone)
        {
            gameObject.SetActive(false);
        }
    }
}
