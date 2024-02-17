using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoPulse : MonoBehaviour
{
    public float pulseSpeed = 1.0f; // Adjust this value to control the pulsing speed
    public float minScale = 0.8f;    // Adjust this value to set the minimum scale
    public float maxScale = 1.2f;    // Adjust this value to set the maximum scale

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Calculate the new scale based on the pulsing speed
        float scaleFactor = Mathf.Sin(Time.time * pulseSpeed);

        // Map the sine wave result to a scale value between minScale and maxScale
        float scale = Mathf.Lerp(minScale, maxScale, (scaleFactor + 1f) / 2f);

        // Apply the new scale to the Raw Image
        rectTransform.localScale = new Vector3(scale, scale, 1f);
    }
}
