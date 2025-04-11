using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScreenUI_Script : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMusicVolumeChange()
    {
        float newVolume = musicVolumeSlider.value;

        if (newVolume <= 0)
        {
            newVolume = -8;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);

            newVolume = newVolume * 20;
        }

        audioMixer.SetFloat("MusicVolume", newVolume);
    }

    public void onSFXVolumeChange()
    {
        float newVolume = SFXVolumeSlider.value;

        if (newVolume <= 0)
        {
            newVolume = -8;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);

            newVolume = newVolume * 20;
        }

        audioMixer.SetFloat("SFXVolume", newVolume);
    }
}
