using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameOver = false;
    public GameObject gameOverScreen;


    void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
