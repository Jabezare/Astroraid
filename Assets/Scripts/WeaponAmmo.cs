using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour {

    public int initialAmmo = 3;
    public int currentAmmo;
    GUIStyle UIStyle = new GUIStyle();

    // Use this for initialization
    void Start () {
        currentAmmo = initialAmmo;
        UIStyle.fontSize = 40;
        UIStyle.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        GUILayout.Label("Bombs: " + currentAmmo.ToString(), UIStyle);
    }
}
