using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private GameObject shopManu;
    [SerializeField] private GameObject[] towers;
    private GameObject selectBuildPoint;

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
            if (Physics.Raycast(ray, out hit, 1200))
            {
                selectBuildPoint = hit.transform.gameObject;
                if (selectBuildPoint.tag == "BuildPoint")
                {
                    shopManu.SetActive(true);
                }
            }
            else if (shopManu.activeInHierarchy == true)
            {
                shopManu.SetActive(false);
            }
        }
    }

    public void PlaceTower(int index)
    {
        Instantiate(towers[index], selectBuildPoint.transform.position, Quaternion.identity);
        shopManu.SetActive(false);
        Destroy(selectBuildPoint);
    }
}
