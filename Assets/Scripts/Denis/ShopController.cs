using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    //public Text money;
    //public float totalMoney = 999f;
    //public float t1cost = 5f;
    //public float t2cost = 15f;
    //public float t3cost = 25f;


    //public void UpdateCoinText()
    //{
    //    money.text = totalMoney.ToString();
    //}

    //public void BuyTurel1()
    //{
    //    if (totalMoney >= t1cost)
    //    {
    //        totalMoney -= t1cost;
    //        UpdateCoinText();
    //    }
    //}

    //public void BuyTurel2()
    //{
    //    if (totalMoney >= t2cost)
    //    {
    //        totalMoney -= t2cost;
    //        UpdateCoinText();
    //    }
    //}

    //public void BuyTurel3()
    //{
    //    if (totalMoney >= t3cost)
    //    {
    //        totalMoney -= t3cost;
    //        UpdateCoinText();
    //    }
    //}

    public void Back()
    {
        ShopPanel.SetActive(false);
    }
}
