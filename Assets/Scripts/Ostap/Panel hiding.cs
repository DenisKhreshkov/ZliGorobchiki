using UnityEngine;

public class PanelHiding : MonoBehaviour
{
    private void Awake()
    {
        Camera.main.GetComponent<AudioListener>().enabled = false;
        Invoke("EndLoad", 2f);
    }

    private void EndLoad()
    {
        Camera.main.GetComponent<AudioListener>().enabled = true;
        Destroy(gameObject);
    }
}
