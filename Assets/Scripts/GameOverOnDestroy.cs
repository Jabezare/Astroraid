using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnDestroy : MonoBehaviour {

    void OnDestroy()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Follower"))
        {
            Destroy(obj);
        }

        if(gameManagerObject != null)
        {
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.gameOver = true;
            GameObject.FindGameObjectWithTag("GamePlayArea").GetComponent<MoveForward>().enabled = false;
            FindObjectOfType<AudioManager>().Stop("backgroundMusic");
            FindObjectOfType<AudioManager>().Play("playerDeathSound");
        }
    }
}
