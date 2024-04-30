using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserSpawner : MonoBehaviour
{

    private KeyCode shootKeyCode = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(shootKeyCode))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = PlayerLaserPoolManager.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }

            bullet.SetActive(true);
        }
    }
}
