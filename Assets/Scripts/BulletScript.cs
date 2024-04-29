using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [Header("Bullet")]
    [SerializeField] private float speed = 10.0f;
    private float disableZone = 6.5f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        DisableBullet();
    }

    private void DisableBullet()
    {
        if (transform.position.y >= disableZone)
        {
            gameObject.SetActive(false);
        }
    }
}
