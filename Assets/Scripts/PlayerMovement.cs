using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;
    public float minX = -5.6f;
    public float maxX = 5.6f;
    public float minY = -10;
    public float maxY = 10;

    // Update is called once per frame
    void Update () {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 pos = transform.localPosition;
        pos += new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minY, maxY);
        transform.localPosition = pos;
    }
}
