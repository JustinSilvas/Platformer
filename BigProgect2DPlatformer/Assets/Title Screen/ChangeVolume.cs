using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeText;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
    }

    public void ChangeVolumeLevel()
    {
        AudioListener.volume = volumeSlider.value; //Changes volume based on slider value
        volumeText.text = volumeSlider.value.ToString();
    }






}
