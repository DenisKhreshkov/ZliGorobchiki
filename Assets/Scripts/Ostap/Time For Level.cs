using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeForLevel : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _totalLevelTime;
    [SerializeField] private float levelTime;
    [Header("Links")]
    [SerializeField] private RectTransform winPanel;
    [SerializeField] private RectTransform blackScreen;
    [SerializeField] private Text timeText;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(LevelTimeline());
        _totalLevelTime = levelTime;
        winPanel.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(false);
    }

    private IEnumerator LevelTimeline()
    {
        while (levelTime > 0f)
        {
            levelTime -= Time.deltaTime;
            timeText.text = levelTime.ToString("F1");
            yield return null;
        }
        timeText.text = "";
        Time.timeScale = 0f;
        blackScreen.gameObject.SetActive(true);
        _audioSource.Play();
        Win();
        yield return new WaitForSecondsRealtime(1f);
        winPanel.gameObject.SetActive(true);
    }

    public void Loose()
    {
        StopAllCoroutines();
        float perfences = (levelTime / _totalLevelTime) * 100;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Map1":
                PlayerPrefs.SetInt("Level1 complete", Mathf.FloorToInt(perfences) );
                break;
            case "Map2":
                PlayerPrefs.SetInt("Level2 complete", Mathf.FloorToInt(perfences) );
                break;
            case "Map3":
                PlayerPrefs.SetInt("Level3 complete", Mathf.FloorToInt(perfences) );
                break;
        }
    }

    public void Win()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Map1":
                PlayerPrefs.SetInt("Level1 complete", 100);
                break;
            case "Map2":
                PlayerPrefs.SetInt("Level2 complete", 100);
                break;
            case "Map3":
                PlayerPrefs.SetInt("Level3 complete", 100);
                break;
        }
        FindObjectOfType<RaycastBlock>().Blocks.SetActive(true);
    }

    public void Menu() => SceneManager.LoadScene(0);
}
