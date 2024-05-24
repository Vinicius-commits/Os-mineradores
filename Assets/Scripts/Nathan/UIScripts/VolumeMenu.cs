using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource; 

    void Start()
    {
        
        if (volumeSlider == null)
        {
            Debug.LogError("Volume Slider not assigned!");
        }
        if (musicSource == null)
        {
            Debug.LogError("Music Source not assigned!");
        }

        
        volumeSlider.value = musicSource.volume;

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    
    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }
}