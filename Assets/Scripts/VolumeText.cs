using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    public Text musicVolume;
    public Slider musicVolumeSlider;
    public Text effectsVolume;
    public Slider effectsVolumeSlider;

    // Update is called once per frame
    void Update()
    {
        musicVolume.text = Mathf.Round(musicVolumeSlider.value / musicVolumeSlider.maxValue * 100).ToString() + "%";
        effectsVolume.text = Mathf.Round(effectsVolumeSlider.value / effectsVolumeSlider.maxValue * 100).ToString() + "%";
    }
}
