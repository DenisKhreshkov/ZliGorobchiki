using UnityEngine;

public class Ambient : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float volumeScale = 1;

    private AudioSource _bgAudioSource;
    private void Start()
    {
        _bgAudioSource = GetComponent<AudioSource>();
        _bgAudioSource.volume = PlayerPrefs.GetFloat("Volume") * volumeScale;
        _bgAudioSource.Play();
        _mainCastle = FindObjectOfType<MainCastle>();
    }
    
    private MainCastle _mainCastle;
    private void LateUpdate()
    {
        if (_mainCastle.MainHealth <= 0) _bgAudioSource.Stop();
    }
}
