using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseSphericalDamage : MonoBehaviour {

    public float damageAmount = 250.0f;
    public float radius = 5.0f;
    public LayerMask layerMask = -1;

	// Use this for initialization
	void Start () {
        foreach (Collider col in Physics.OverlapSphere(transform.position, radius, layerMask))
        {
            EnemyHealth targetHealthScript = col.GetComponentInChildren<EnemyHealth>();
            if (targetHealthScript)
            {
                targetHealthScript.TakeDamage(damageAmount, col.transform.position);
            }
        }
	}
}
