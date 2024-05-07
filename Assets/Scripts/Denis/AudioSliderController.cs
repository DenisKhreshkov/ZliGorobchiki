using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Awake() => PlayerPrefs.SetFloat("Volume", 1);
    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = audioSource.volume;
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
