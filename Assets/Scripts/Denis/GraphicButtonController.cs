using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicButtonController : MonoBehaviour
{
    public void SetQualityHigh(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
    public void SetQualityMedium(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }

    public void SetQualityLow(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
}
