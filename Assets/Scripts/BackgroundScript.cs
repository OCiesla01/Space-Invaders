using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    [Header("Background Movement")]
    [SerializeField] private float backgroundSpeed = 0.1f;
    [SerializeField] private float snapZone = -10.3f;
    private Vector3 resetPosition = new Vector3(0, 0, 1);

    void Update()
    {
        if (transform.position.y <= snapZone)
        {
            ResetPosition();
        }

        transform.Translate(Vector2.down * backgroundSpeed * Time.deltaTime);
    }

    private void ResetPosition()
    {
        transform.position = resetPosition;
    }
}
