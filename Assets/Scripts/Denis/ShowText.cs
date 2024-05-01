using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject showText;

    void Start()
    {
        showText.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        showText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        showText.SetActive(false);
    }

    public void LVL1() => SceneManager.LoadScene(1);


    public void LVL2() => SceneManager.LoadScene(2);


    public void LVL3() => SceneManager.LoadScene(3);
}
