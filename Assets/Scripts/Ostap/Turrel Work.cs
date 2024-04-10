using UnityEngine;

public class TurrelWork : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private float interval = 1f;
    [SerializeField] private float visibleZone = 10f;

    private Transform _gunTransform;
    private Transform _handleTransform;
    private GameObject _enemyTarget;
    private GameObject[] enemies;

    private float _closestDistance;
    private float _distanceToEnemy;
    private bool _canSeeTarget;
    private void OnEnable()
    {
        _gunTransform = transform.Find("Gun");
        _handleTransform = transform.Find("Gun/Stick/Handle");
        Invoke("Shot", 0.5f);
    }
    private void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _closestDistance = visibleZone;
        foreach (GameObject enemy in enemies)
        {
            _distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (_distanceToEnemy < _closestDistance)
            {
                _enemyTarget = enemy;
                _closestDistance = _distanceToEnemy;
                _canSeeTarget = true;
            } else
            {
                _canSeeTarget = false;
            }
        }
    }

    private void Update()
    {
        if (_canSeeTarget) 
        _gunTransform.LookAt(_enemyTarget.transform.position);
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
