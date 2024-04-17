using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private Text money;

    [SerializeField] private int totalMoney = 999;

    void Update()
    {
        
    }

    public void UpdateCoinText()
    {
        money.text = totalMoney.ToString();
    }

    public void BuyTurel1()
    {
        if(totalMoney >= 5)
        {
            totalMoney -= 5;
            UpdateCoinText();
        }
    }
}
