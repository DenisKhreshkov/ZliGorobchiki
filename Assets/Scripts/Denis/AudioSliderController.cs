using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Start()
    {
        volumeSlider.value = audioSource.volume;
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
