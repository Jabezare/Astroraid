using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public float shotDelay = 0.2f;
    private bool readyToShoot = true;

	void Start()
    {
        Invoke("Shoot", shotDelay);
    }
    
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        Invoke("Shoot", shotDelay);
    }
}
