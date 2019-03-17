using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibAfterDelay : MonoBehaviour {

    public GameObject gib = null;
    public GameObject objectToDestroy = null;
    public float delay = 1.0f;

	// Use this for initialization
	void Start () {
        if (objectToDestroy == null)
        {
            objectToDestroy = gameObject;
        }
        Invoke("Gib", delay);
	}
	
	
	void Gib () {
        if (gib != null)
        {
            Instantiate(gib, transform.position, gib.transform.rotation);
        }
        if (transform.parent != null)
        {
            transform.parent.SendMessage("Dead", transform.position, SendMessageOptions.DontRequireReceiver);
        }
        Destroy(objectToDestroy);
    }
}
