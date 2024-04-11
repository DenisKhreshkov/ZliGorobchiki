using UnityEngine;

public class GunShot : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(damage);
        }
        Destroy(gameObject);
    }
}
