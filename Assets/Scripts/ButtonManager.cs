using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private int lastLevel;

    void Start()
    {
        lastLevel = PlayerPrefs.GetInt("lastLevelPlayed", 1);
    }

    public void LoadSceneButton(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextButton()
    {
        if (lastLevel != 8)
        {
            SceneManager.LoadScene(lastLevel + 1);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }

    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
