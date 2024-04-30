using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLAserSpawner : MonoBehaviour
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
            bullet.SetActive(true);
        }
    }
}
