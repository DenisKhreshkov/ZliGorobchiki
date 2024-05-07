using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private GameObject shopManu;
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject selectBuildPoint;

    private Camera camera;
    public ShopController shop;
    RaycastHit hit;

    void Start()
    {
        shop = GetComponent<ShopController>();
        camera = Camera.main;
    }
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1200f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1200, 1<<6) && GlobalVar.CanBuild)
            {
                selectBuildPoint = hit.transform.gameObject;

                if (selectBuildPoint.tag == "BuildPoint")
                {
                    shopManu.SetActive(true);
                    GlobalVar.CanBuild = false;
                }
            }
        }
    }

    public void BuyTower(int index)
    {
        if (index == 0)
        {
            shop.BuyTurel1();
            PlaceTower(index);
        }
        if (index == 1)
        {
            shop.BuyTurel2();
            PlaceTower(index);
        }
        if (index == 2)
        {
            shop.BuyTurel3();
            PlaceTower(index);
        }
    }

    public void PlaceTower(int index)
    {
        Instantiate(towers[index], selectBuildPoint.transform.position, Quaternion.identity);
        shopManu.SetActive(false);
        Invoke("CanBuild",0.1f);
    }

    private void CanBuild() => GlobalVar.CanBuild = true;
}
