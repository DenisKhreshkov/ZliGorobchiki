using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DragonPath : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    [SerializeField] private MainCastle _mainCastle;
    [SerializeField] private Transform towerTransform;
    [SerializeField] private float health;
    [SerializeField] private float attackPower;
    [SerializeField] private float interval;
    private bool _alive = true;
    private bool _attacking = false;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _mainCastle = FindObjectOfType<MainCastle>();
        towerTransform = GameObject.FindGameObjectWithTag("Finish").transform;
        _agent.SetDestination(towerTransform.position);
    }

    private void FixedUpdate()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && !_attacking && _alive)
        {
            _attacking = true;
            StartCoroutine(StartAttack());
        } 
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health < 0.1f && _alive)
        {
            _alive = false;
            _agent.speed = 0f;
            _animator.SetTrigger("Death");
            gameObject.tag = "Default";
            Destroy(gameObject, 4f);
        }
    }

    public void End()
    {
        if ( _alive )
        {
            _animator.SetTrigger("Iddle");
            _agent.speed = 0f;
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        Invoke("Attack", interval);
        _mainCastle.MainHealth -= attackPower;
    }

    private IEnumerator StartAttack()
    {
        while (_alive)
        {
            _animator.SetTrigger("Attack");
            for (int i = 0; i < 1/Time.fixedDeltaTime; i++)
            {
                _mainCastle.MainHealth -= attackPower * Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate(); 
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
