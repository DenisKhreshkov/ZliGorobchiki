using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DragonPath : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Canvas _canvas;
    private Slider _healthSlider;
    private MainCastle _mainCastle;
    private Transform _towerTransform;

    [SerializeField] private Image healthFill;
    [SerializeField] private float health;
    [SerializeField] private float attackPower;
    [SerializeField] private float interval;

    private bool _alive = true;
    private bool _attacking = false;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _canvas = GetComponentInChildren<Canvas>();
        _healthSlider = GetComponentInChildren<Slider>();
        _mainCastle = FindObjectOfType<MainCastle>();
        _canvas.worldCamera = Camera.main;
        _healthSlider.maxValue = health;
        _healthSlider.value = health;
        _towerTransform = GameObject.FindGameObjectWithTag("Finish").transform;
        _agent.SetDestination(_towerTransform.position);
    }

    private void FixedUpdate()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && !_attacking && _alive)
        {
            _attacking = true;
            StartCoroutine(StartAttack());
            _agent.avoidancePriority = 90;
        } 
        if (_canvas.worldCamera != null)
        _canvas.transform.rotation = Camera.main.transform.rotation;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        _healthSlider.value = health;
        healthFill.color = new Color(1, (health / _healthSlider.maxValue) + 0.1f , 0);
        if (health < 0.1f && _alive)
        {
            _alive = false;
            _agent.speed = 0f;
            _agent.avoidancePriority = 99; 
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
