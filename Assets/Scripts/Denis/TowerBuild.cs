using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    public void BuyTurel1()
    {
        if (totalMoney >= 5)
        {
            totalMoney -= 5;
            UpdateCoinText();
        }
    }

    public void PlaceTower(int index)
    {
        BuyTurel1();
        Instantiate(towers[index], selectBuildPoint.transform.position, Quaternion.identity);
        shopManu.SetActive (false);
    }
}
