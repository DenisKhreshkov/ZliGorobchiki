using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject audioPanel;

    public Slider volumeSlider;
    private AudioSource audioSource;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();

        volumeSlider.value = audioSource.volume;

    }

    public void ChangeVolume()
    {

        audioSource.volume = volumeSlider.value;

    }
    
    public void BackButton()
    {
        audioPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
