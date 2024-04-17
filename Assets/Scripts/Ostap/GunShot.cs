using UnityEngine;

public class GunShot : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<DragonPath>().GetDamage(damage);
        }
        Destroy(gameObject);
    }
}
