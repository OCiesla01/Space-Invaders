using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserSpawner : MonoBehaviour
{

    [Header("Player Laser Spawner Config")]
    [SerializeField] private KeyCode shootKeyCode = KeyCode.Space;

    private WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = GameObject.Find("Wave").GetComponent<WaveSpawner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKeyCode))
        {
            Shoot();
        }
    }

    // Player laser shoot
    private void Shoot()
    {
        if (waveSpawner.isWaveSpawned)
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

                AudioManager.instance.PlayLaserShot();
                bullet.SetActive(true);
            }
        }
    }
}
