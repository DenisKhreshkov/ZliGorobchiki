using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject ShopPanel2;
    public Text money;
    public float totalMoney = 999f;
    public float t1cost = 5f;
    public float t2cost = 10f;
    public float t3cost = 20f;
    public float b1cost = 5f;
    public float b2cost = 10f;


    public void UpdateCoinText()
    {
        money.text = totalMoney.ToString();
    }

    public void BuyTurel1()
    {
        if (totalMoney >= t1cost)
        {
            totalMoney -= t1cost;
            UpdateCoinText();
        }
    }

    public void BuyTurel2()
    {
        if (totalMoney >= t2cost)
        {
            totalMoney -= t2cost;
            UpdateCoinText();
        }
    }

    public void BuyTurel3()
    {
        if (totalMoney >= t3cost)
        {
            totalMoney -= t3cost;
            UpdateCoinText();
        }
    }

    public void BuyBarrier1()
    {
        if (totalMoney >= b1cost)
        {
            totalMoney -= b1cost;
            UpdateCoinText();
        }
    }

    public void BuyBarrier2()
    {
        if (totalMoney >= b2cost)
        {
            totalMoney -= b2cost;
            UpdateCoinText();
        }
    }

    public void Back()
    {
        ShopPanel.SetActive(false);
        GlobalVar.CanBuild = true;
    }

    public void Back2()
    {
        ShopPanel2.SetActive(false);
        GlobalVar.CanBuild = true;
    }

    private void Start() => Invoke("AddMoney", 8f);

    private void AddMoney()
    {
        totalMoney += Random.Range(1, 4);
        UpdateCoinText();
        Invoke("AddMoney", 3f);
    }
}
