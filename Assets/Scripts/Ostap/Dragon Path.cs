using UnityEngine;
using UnityEngine.AI;

public class DragonPath : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform towerTransform;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float attackPower;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(towerTransform.position);
        agent.speed = speed;
    }



    public void GetDamage(float damage)
    {
        health -= damage;
        agent.speed = 0;
        animator.SetTrigger("hit");
        Invoke("ContinuePath", 0.8f);
        if (health < 0.1f)
        {
            agent.enabled = false;
            animator.SetTrigger("Death");
            gameObject.tag = null;
            Destroy(gameObject, 4f);
        }
    }

    private void ContinuePath()
    {
        agent.speed = speed;
    }

}
