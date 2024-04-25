using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject PauseManu;
    private AudioSource _ambient; private void Start() => _ambient = FindObjectOfType<Ambient>().GetComponent<AudioSource>();
    public void Resume()
    {
        PauseManu.SetActive(false);
        Time.timeScale = 1.0f;
        _ambient.Play();
    }

    public void Pause()
    {
        PauseManu.SetActive(true);
        Time.timeScale = 0f;
        _ambient.Pause();
    }

    public void Exit()
    {
        SceneManager.LoadScene("DenisScene");
    }
}
