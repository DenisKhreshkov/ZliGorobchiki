using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject PauseManu;
    public void Resume()
    {
        PauseManu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        PauseManu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("DenisScene");
    }

}
