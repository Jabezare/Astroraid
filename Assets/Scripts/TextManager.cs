using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text currentScore;
    public Text highScore;

    // Update is called once per frame
    void Update()
    {
        currentScore.text = ("Score: " + PlayerPrefs.GetInt("currentscore").ToString());
        highScore.text = ("Top score: " + PlayerPrefs.GetInt("highscore").ToString());
    }
}
