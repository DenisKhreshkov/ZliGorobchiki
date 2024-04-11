using System.Collections;
using System.Collections.Generic;
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

    public void ShopActiveTrue()
    {
        ShopPanel.SetActive(true);
    }

    public void ShopActiveFalse()
    {
        ShopPanel.SetActive(false);
    }

    public void BuyTurel1()
    {
        if(totalMoney >= 5)
        {
            totalMoney -= 5;
            UpdateCoinText();
        }
    }
    public void BuyTurel2()
    {
        if (totalMoney >= 20)
        {
            totalMoney -= 20;
            UpdateCoinText();
        }
    }

    public void BuyTurel3()
    {
        if (totalMoney >= 30)
        {
            totalMoney -= 30;
            UpdateCoinText();
        }
    }

    public void BuyTowerl1()
    {
        if (totalMoney >= 5)
        {
            totalMoney -= 5;
            UpdateCoinText();
        }
    }

    public void BuyTowerl2()
    {
        if (totalMoney >= 20)
        {
            totalMoney -= 20;
            UpdateCoinText();
        }
    }

    public void BuyTowerl3()
    {
        if (totalMoney >= 30)
        {
            totalMoney -= 30;
            UpdateCoinText();
        }
    }
}
