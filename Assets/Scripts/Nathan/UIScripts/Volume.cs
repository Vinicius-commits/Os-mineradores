using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Volume : MonoBehaviour
{
    public Slider sliderVolume; 

    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        
        sliderVolume.value = audioSource.volume;
        
        
        sliderVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }

    
    void OnVolumeChanged()
    {
        
        audioSource.volume = sliderVolume.value;
    }
}