using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleWhenFinished : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
		if(!particleSystem.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
