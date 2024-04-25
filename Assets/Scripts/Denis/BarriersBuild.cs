using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarriersBuild : MonoBehaviour
{
    [SerializeField] private GameObject shopManu;
    [SerializeField] private GameObject[] barriers;
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
            if (Physics.Raycast(ray, out hit, 1200, 1 << 6))
            {
                selectBuildPoint = hit.transform.gameObject;

                if (selectBuildPoint.tag == "BuildBarrier")
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

    public void BuyBarrier()
    {
        if (totalMoney >= 5)
        {
            totalMoney -= 5;
            UpdateCoinText();
        }
    }

    public void PlaceBarrier(int index)
    {
            BuyBarrier();
            Instantiate(barriers[index], selectBuildPoint.transform.position, Quaternion.identity);
            shopManu.SetActive(false);
    }

}
