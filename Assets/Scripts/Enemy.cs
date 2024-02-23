using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator unitAnimator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceAggro;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;

    private bool hasAggro = false;
    private float distanceToPlayer;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        ChasePlayer();
        Attack();
    }

    private void ChasePlayer()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer < distanceAggro && distanceToPlayer > attackRange)
        {
            hasAggro = true;
            transform.LookAt(playerTransform);
            transform.position += (transform.forward * moveSpeed * Time.deltaTime);
            unitAnimator.SetBool("IsWalking", true);
            unitAnimator.SetBool("IsAttacking", false);
        } 

        if (distanceToPlayer > distanceAggro)
        {
            hasAggro = false;
            unitAnimator.SetBool("IsWalking", false);
            unitAnimator.SetBool("IsAttacking", false);
        }

    }

    private IEnumerator EnemyPlayerKillDelay()
    {
        yield return new WaitForSeconds(attackSpeed);
        {
            Destroy(Player.instance.gameObject);
            Debug.Log("Attack");
            StopCoroutine(EnemyPlayerKillDelay());
        }
    }

    private void Attack()
    {
        if (distanceToPlayer <= attackRange && hasAggro == true)
        {
            unitAnimator.SetBool("IsWalking", false);
            unitAnimator.SetBool("IsAttacking", true);

            StartCoroutine(EnemyPlayerKillDelay());
        } 
        else if (distanceToPlayer > attackRange && hasAggro == true)
        {
            unitAnimator.SetBool("IsWalking", true);
            unitAnimator.SetBool("IsAttacking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            UI.instance.scorePoints += 1;
        }
    }
}
