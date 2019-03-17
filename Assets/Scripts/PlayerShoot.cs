using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    public string shotButton = "Fire1";
    public float shotDelay = 0.2f;
    public WeaponAmmo ammo;
    private bool readyToShoot = true;

	// Update is called once per frame
	void Update () {
        if (ammo == null || ammo.currentAmmo > 0)
        {
		    if(Input.GetButton(shotButton) && readyToShoot)
            {
                if (GetComponent<AudioSource>() != null)
                {
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        GetComponent<AudioSource>().Play();
                    }
                }
                if (ammo != null)
                {
                    ammo.currentAmmo--;
                }
                Instantiate(bullet, transform.position, transform.rotation);
                readyToShoot = false;
                Invoke("ResetReadyToShoot", shotDelay);
            }
        }
	}

    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }
}
