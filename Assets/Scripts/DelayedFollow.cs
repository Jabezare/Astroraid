using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFollow : MonoBehaviour {

    public Transform followTransform;
    public int frameDelay = 60;

    private List<Vector3> positionList = new List<Vector3>();
    
    // Use this for initialization
	void Start () {
        for (int i = 0; i < frameDelay; i++)
        {
            positionList.Add(followTransform.localPosition);
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            if (followTransform != null)
            {
                positionList.Add(followTransform.localPosition);
                if (positionList.Count > frameDelay)
                {
                    positionList.RemoveAt(0);
                    transform.localPosition = positionList[0];
                }
            }
        }
	}
}
