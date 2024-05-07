using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject selectLvlPanel;

    public void StartButton()
    {
        selectLvlPanel.SetActive(true);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Back()
    {
        selectLvlPanel.SetActive(false);
    }
}
