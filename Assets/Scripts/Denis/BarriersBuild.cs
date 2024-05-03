using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarriersBuild : MonoBehaviour
{
    [SerializeField] private GameObject shopManu2;
    [SerializeField] private GameObject[] barriers;
    [SerializeField] private GameObject selectBuildPoint;

    private Camera camera;
    public ShopController shop;
    RaycastHit hit;

    void Start()
    {
        camera = Camera.main;
        shop = GetComponent<ShopController>();
    }
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1200f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1200, 1 << 6) && GlobalVar.CanBuild)
            {
                selectBuildPoint = hit.transform.gameObject;
                if (selectBuildPoint.tag == "BuildBarrier")
                {
                    shopManu2.SetActive(true);
                }
            }
        }
    }

    public void BuyBarrier(int index)
    {
        if (index == 0)
        {
            shop.BuyBarrier1();
            PlaceBarrier(index);
        }

        if (index == 1)
        {
            shop.BuyBarrier2();
            PlaceBarrier(index);
        }

    }

    public void PlaceBarrier(int index)
    {
            Instantiate(barriers[index], selectBuildPoint.transform.position, Quaternion.identity);
            shopManu2.SetActive(false);
    }

}
