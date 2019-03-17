using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderAI : MonoBehaviour {
    public float speed = 1.0f;
    public float sinAmplitude = 1.0f;
    public float sinFrequency = 1.0f;
    private float horizontaOffset = 0.0f;
    private float time;

    void Update()
    {
        time += Time.deltaTime;

        transform.position -= horizontaOffset * transform.right;

        transform.position += transform.forward * speed * Time.deltaTime;

        horizontaOffset = Mathf.Sin(time * sinFrequency * 2 * Mathf.PI) * sinAmplitude;

        transform.position += horizontaOffset * transform.right;
    }
}
