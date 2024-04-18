using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;

    public void Back()
    {
        ShopPanel.SetActive(false);
    }
}
