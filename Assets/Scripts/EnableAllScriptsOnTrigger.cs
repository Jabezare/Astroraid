using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAllScriptsOnTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        foreach(MonoBehaviour mono in gameObject.GetComponentsInChildren<MonoBehaviour>())
        {
            mono.enabled = true;
        }
    }
}
