using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnDestroy : MonoBehaviour {

    private string levelName = "Victory";

    void OnDestroy()
    {
        PlayerPrefs.SetInt("lastLevelPlayed", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
