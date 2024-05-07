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

    [SerializeField] private float liveTime;
    private void Awake()
    {
        StartCoroutine(TurrelLive());
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

    private IEnumerator Shake()
    {
        float shakeX;
        float shakeZ;
        while (true)
        {
            shakeX = Random.Range(-0.3f, 0.3f);
            shakeZ = Random.Range(-0.3f, 0.3f);
            transform.position = new Vector3(transform.position.x + shakeX, transform.position.y, transform.position.z + shakeZ);
            yield return new WaitForSeconds(0.05f);
            transform.position = new Vector3(transform.position.x - shakeX, transform.position.y, transform.position.z - shakeZ);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator TurrelLive()
    {
        yield return new WaitForSeconds(liveTime);
        StartCoroutine(Shake());
        yield return new WaitForSeconds(2f);
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = false;
        }
        IsWorking = false;
        GetComponent<AudioSource>().Play();
        GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject, 2f);
        StopAllCoroutines();
    }
}
