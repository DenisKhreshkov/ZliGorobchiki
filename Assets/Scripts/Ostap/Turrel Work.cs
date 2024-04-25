using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class TurrelWork : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private float interval = 1f;
    [SerializeField] private float speed = 5f;

    [SerializeField] private Transform _gunTransform;
    [SerializeField] private Transform _handleTransform;
    private GameObject _target;

    public bool IsWorking = true;
    private void Awake()
    {
       //s Invoke("Shot", 0.5f);
    }
    /*  private void FixedUpdate()
      {
          enemies = GameObject.FindGameObjectsWithTag("Enemy");
          foreach (GameObject enemy in enemies)
          {
              _distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
              if (_distanceToEnemy < visibleZone)
              {
                  _enemyTarget = enemy;
                  _canSeeTarget = true;
              } else
              {
                  _canSeeTarget = false;
                  _enemyTarget = null;
              }
          }

          Debug.Log(_enemyTarget.name);
      } */

    IEnumerator OnFire()
    {
        while (ammo != null && IsWorking)
        {
        GameObject getBullet = Instantiate(ammo, _handleTransform.position, Quaternion.identity);
        _handleTransform.LookAt(_target.transform.position);

        Rigidbody rb = getBullet.GetComponent<Rigidbody>();
        rb.AddForce(_handleTransform.forward * speed, ForceMode.Impulse);

        yield return new WaitForSeconds(interval);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy") && _target == null)
        {
            _target = other.gameObject;
            StartCoroutine(OnFire());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && _target != null)
        {
            _target = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && _target == null)
        {
            _target = other.gameObject;
            StartCoroutine(OnFire());
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _gunTransform.LookAt( _target.transform.position );
            if (_target.GetComponent<NavMeshAgent>().speed < 0.01f)
            _target = null;
        }
        
    }

}
