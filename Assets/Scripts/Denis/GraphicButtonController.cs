using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicButtonController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject graphicPanel;

    public void SetQualityHight()
    {

    }

    public void SetQualityMedium()
    {

    }

    public void SetQualityLow()
    {

    }

    public void BackButton()
    {
        graphicPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
