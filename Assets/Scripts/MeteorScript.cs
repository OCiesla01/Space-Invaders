using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    void Update()
    {
        transform.Translate(Vector3.right * GetRandomMeteorSpeed() * Time.deltaTime);
    }

    private float GetRandomMeteorSpeed()
    {
        return Random.Range(1, 4);
    }
}
