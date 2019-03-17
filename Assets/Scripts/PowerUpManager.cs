using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public PlayerShoot[] weapons;
    private int powerLevel = -1;

    void PowerUp()
    {
        GetComponent<AudioSource>().Play();
        powerLevel++;
        if(powerLevel < weapons.Length)
        {
            weapons[powerLevel].enabled = true;
            if(powerLevel == 4)
            {
                GameObject.FindObjectOfType<WeaponAmmo>().enabled = true;
            }
        }
    }
}
