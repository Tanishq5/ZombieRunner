using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] float ChaseRange = 5f;
    [SerializeField] float TurnSpeed = 5f;
    [SerializeField] AudioClip EnemySound;

    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    Transform target;
    AudioSource audioSource;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }

        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= ChaseRange)
        {
            isProvoked = true;
        }

        if(distanceToTarget <= 10f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(EnemySound);
            }
        }
    }

    public void OnDamage()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * TurnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
}
