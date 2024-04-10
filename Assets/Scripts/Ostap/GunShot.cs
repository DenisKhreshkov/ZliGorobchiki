using UnityEngine;

public class GunShot : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage = 1f;
    private Rigidbody rb;
    private Vector3 velocity;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        velocity = transform.forward * -speed;
        rb.velocity = velocity;
        Destroy(gameObject, 20f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(damage);
        }
        Destroy(gameObject);
    }
}
