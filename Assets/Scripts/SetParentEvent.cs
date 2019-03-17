using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentEvent : MonoBehaviour {

    public Transform target;
    public string newParentTag;

    void SetParent()
    {
        Transform newParent = GameObject.FindGameObjectWithTag(newParentTag).transform;

        if(target == null)
        {
            transform.parent = newParent;
        }
        else
        {
            target.parent = newParent;
        }
    }
}
