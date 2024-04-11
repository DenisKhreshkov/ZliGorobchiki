using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject PauseManu;
    public void Resume()
    {
        PauseManu.SetActive(false);
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
