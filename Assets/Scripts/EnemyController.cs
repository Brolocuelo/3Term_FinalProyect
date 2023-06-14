using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private NavMeshAgent _agent;

    private float visionRange = 6f;
    private float attackRange = 4f;

    [SerializeField]
    private bool playerInVisionRange;
    [SerializeField]
    private bool playerInAttackRange;

    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform[] waypoints;
    private int totalWaypoints;
    private int nextPoint;

    [SerializeField] private Transform bullet;
    [SerializeField] private Transform[] spawnPoint;
    private float timeBetweenAttacks = 5;
    private bool canAttack;
    
    //private float forwardAttackForce = 8f;

    private int Counter;

    private float yRange = 10f;


    public Transform firePoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Counter = 0;
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Counter++;
        }

        if (other.gameObject.CompareTag("Bullet") && Counter >= 3)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(pos, attackRange, playerLayer);

        if (!playerInVisionRange && !playerInAttackRange)
        {
            Patrol();
        }

        if (playerInVisionRange && !playerInAttackRange)
        {
            Chase();
        }

        if (playerInAttackRange)
        {
            Attack();
        }

        
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[nextPoint].position) < 2.5f)
        {
            nextPoint++;
            if (nextPoint == totalWaypoints)
            {
                nextPoint = 0;
            }
            transform.LookAt(waypoints[nextPoint].position);
        }
        _agent.SetDestination(waypoints[nextPoint].position);
    }

    private void Chase()
    {
        _agent.SetDestination(player.position);
        transform.LookAt(new Vector3 (player.position.x,0.5f,0));
    }

    private void Attack()
    {
        if (canAttack)
        {
            Vector3 forceDirection = player.position - firePoint.position;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            //Rigidbody rigidbody = Instantiate(bullet, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rigidbody.AddForce(forceDirection.normalized * forwardAttackForce, ForceMode.Impulse);

            canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        //Esfera Vision
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        //Esfera Ataque
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void SpawnEnemy()
    {
        Vector3 pos = transform.position;

        if (pos.y < -yRange)
        {
            transform.position = new Vector3(10, 1, 0);
        }
    }
}
