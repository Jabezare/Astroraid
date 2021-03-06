﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float verticalScrollSpeed = 1.0f;
    public float horizontalScrollMultiplier = 1.0f;

    private GameObject player;
    
    
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            Vector2 newTextureOffset = GetComponent<Renderer>().material.mainTextureOffset;

            newTextureOffset.x = player.transform.position.x * horizontalScrollMultiplier;
            newTextureOffset.y += verticalScrollSpeed * Time.deltaTime;

            GetComponent<Renderer>().material.mainTextureOffset = newTextureOffset;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
