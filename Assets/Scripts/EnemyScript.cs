using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject enemyLaser;
    public float minTimeToShoot;
    public float maxTimeToShoot;

    void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    IEnumerator ShootingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToShoot, maxTimeToShoot));
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject laser = EnemyLaserPoolManager.instance.GetPooledObject();

        if (laser != null)
        {
            laser.transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            laser.SetActive(true);
        }
    }
}
