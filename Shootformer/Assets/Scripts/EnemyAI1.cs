using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI1 : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject projectile;

    public float health = 10;

    public GameObject shootPoint;

    public Transform PatrolNode1;
    public Transform PatrolNode2;

    public GameManager gm;

    public bool Node1Reached = false;

    public float TimeBetweenNodes;

    public float damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange && gm.isFirstPerson) Chase();
        if (playerInSightRange && playerInAttackRange && gm.isFirstPerson) Attack();
        

        if (gm.isFirstPerson == false)
        {
            Vector3 position = transform.position;
            position.z = 0;
            transform.position = position;
            Patrolling();
        }

       
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
            
    //    }
    //}

    public void TakeDamage()
    {
        Debug.Log("Enemy Hit");
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void Patrolling()
    {

        Debug.Log("Is Patrolling");
        if (gm.isFirstPerson == true)
        {
            

            Node1Reached = false;

            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet)
            {
                agent.SetDestination(walkPoint);
            }

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
        else
        {
            if (Node1Reached == false)
            {
                StartCoroutine(NodePatrol());
                walkPointSet = false;
            }

            
            
            
        }
        
    }

    IEnumerator NodePatrol()
    {
        agent.SetDestination(PatrolNode1.position);
        Node1Reached = true;
        Debug.Log("Node 1 Reached");
        yield return new WaitForSeconds(TimeBetweenNodes);
        agent.SetDestination(PatrolNode2.position);
        yield return new WaitForSeconds(TimeBetweenNodes);
        Debug.Log("Node 2 Reached");
        Node1Reached = false;
        walkPointSet = false;
    }
    

    

    private void SearchWalkPoint()
    {
        Debug.Log("Searching for Walk Point");
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Chase()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);
        walkPointSet = false;
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            StartCoroutine(DestroyProjectile());
            
        }
        walkPointSet = false;
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3f);
        Destroy(projectile);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
