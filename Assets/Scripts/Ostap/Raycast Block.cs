using UnityEngine;

public class RaycastBlock : MonoBehaviour
{
    private Camera camera = Camera.main;
    public GameObject Blocks;

    private void Start() => Blocks = Instantiate(Blocks, camera.transform.position, transform.rotation);
}
