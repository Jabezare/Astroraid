using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public string PlayerPref;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(PlayerPref, 0.75f);
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(PlayerPref, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(PlayerPref, sliderValue);
    }
}