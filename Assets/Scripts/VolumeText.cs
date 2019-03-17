using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    public Text volume;
    public Slider volumeSlider;

    // Update is called once per frame
    void Update()
    {
        volume.text = Mathf.Round(volumeSlider.value / volumeSlider.maxValue * 100).ToString() + "%";
    }
}
