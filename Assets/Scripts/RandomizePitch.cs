using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePitch : MonoBehaviour {

    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;
    
    // Use this for initialization
	void Start () {
        GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
	}
}
