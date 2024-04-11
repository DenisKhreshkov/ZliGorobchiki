using UnityEngine;

public class TurrelWork : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private float interval = 1f;
    [SerializeField] private float visibleZone = 10f;

    [SerializeField] private Transform _gunTransform;
    [SerializeField] private Transform _handleTransform;
    private GameObject _enemyTarget;
    [SerializeField] private GameObject[] enemies;

    private float _distanceToEnemy;
    private bool _canSeeTarget;
    private void Awake()
    {
        Invoke("Shot", 0.5f);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("d");
            _gunTransform.LookAt(other.transform.position);
        }
    }

    private void Update()
    {
     //   if (_canSeeTarget && _enemyTarget != null) 
        
    }

    private void Shot()
    {
        if (_canSeeTarget)
        {
            Quaternion additionalRotation = Quaternion.Euler(90f, 0f, 0f);
            Quaternion finalRotation = _handleTransform.rotation * additionalRotation;

            Instantiate(ammo, _handleTransform.position, finalRotation);
        }
        Invoke("Shot", interval);
    }
}
