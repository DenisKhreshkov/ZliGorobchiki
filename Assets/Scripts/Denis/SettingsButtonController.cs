using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsButtonController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject graphicPanel;
    [SerializeField] private GameObject mainPanel;

    public void GraphicButton()
    {
        settingsPanel.SetActive(false);
        graphicPanel.SetActive(true);
    }

    public void AudioButton()
    {
        settingsPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void BackButton()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
