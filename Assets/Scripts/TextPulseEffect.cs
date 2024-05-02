using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPulseEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private float pulseSpeed = 1.25f;
    [SerializeField] private float maxScale = 1.0f;
    [SerializeField] private float minScale = 0.9f;
    [SerializeField] private float minAlpha = 0.0f;
    [SerializeField] private float maxAlpha = 1.0f;

    void Update()
    {
        float pulse = Mathf.Sin(Time.time * pulseSpeed) * (maxScale - minScale) / 2 + (maxScale + minScale) / 2;
        textMesh.transform.localScale = Vector3.one * pulse;

        float pulseAlpha = Mathf.Sin(Time.time * pulseSpeed) * (maxAlpha - minAlpha) / 2 + (maxAlpha + minAlpha) / 2;
        Color color = textMesh.color;
        color.a = pulseAlpha;
        textMesh.color = color;
    }
}
