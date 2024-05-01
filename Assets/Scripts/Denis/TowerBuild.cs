using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.PlasticSCM.Editor;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private GameObject shopManu;
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject selectBuildPoint;
    [SerializeField] private Text money;
    [SerializeField] private int totalMoney = 999;

    private Camera camera;
    RaycastHit hit;

    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1200f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1200, 1<<6))
            {
                selectBuildPoint = hit.transform.gameObject;

                if (selectBuildPoint.tag == "BuildPoint")
                {
                    shopManu.SetActive(true);
                }
            }
        }
    }

    public void UpdateCoinText()
    {
        money.text = totalMoney.ToString();
    }

    public void BuyTower(int index)
    {
        if (index == 0)
        {
            if (totalMoney >= 15)
            {
                totalMoney -= 15;
                UpdateCoinText();
                PlaceTower(index);
            }
        }
        if (index == 1)
        {
            if (totalMoney >= 20)
            {
                totalMoney -= 20;
                UpdateCoinText();
                PlaceTower(index);
            }
        }
        if (index == 2)
        {
            if (totalMoney >= 30)
            {
                totalMoney -= 30;
                UpdateCoinText();
                PlaceTower(index);
            }
        }
    }

    public void PlaceTower(int index)
    {
        Instantiate(towers[index], selectBuildPoint.transform.position, Quaternion.identity);
        shopManu.SetActive(false);
    }
}
