using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/* EnemyAI.cs
*   Author: Ethan Sowle
*   Description: A class that controls the enemy's AI behavior.
*   Parametes: None
*   Return: None
*   Date Created: 4/11/2024
*   Date Modified: 4/11/2024
*/

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navMeshAgent;
    public Transform target;
    public GameObject playerOBJ;
    public float pathUpdateDelay = 0.2f;
    private float pathUpdateDeadline;
    public int maxHealth = 5;
    private int currentHealth;
    public int attackDMG = 2;
    private float attackRange;
    public float attackDelay = 1.0f;
    private bool isAttacking = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        attackRange = navMeshAgent.stoppingDistance;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= attackRange;

            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
        }

        // Check if the player is within attack range
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // Attack the player if they are within range
        if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
    }

    // Function to look at the target
    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    // Function to track target
    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            //Debug.Log("Updating path");
            pathUpdateDeadline = Time.time + pathUpdateDelay;
            navMeshAgent.SetDestination(target.position);
        }
    }

    // Function to attack the player
    public void Attack()
    {
        // Only attack if not already attacking
        if(!isAttacking)
        {
            // Set attacking bool to true
            isAttacking = true;

            // Get the player's health script
            Player playerHealth = playerOBJ.GetComponent<Player>();

            // Reduce the player's health
            playerHealth.TakeDamage(attackDMG);

            // Start attack delay coroutine
            StartCoroutine(AttackDelay());
        }
    }

    // Coroutine for attack delay
    IEnumerator AttackDelay()
    {
        // Wait for attack delay and reset attacking bool
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        // Reduce the current health by the damage amount.
        currentHealth -= damage;

        Debug.Log("Enemy took " + damage + " damage.");
        Debug.Log("Current health: " + currentHealth);

        // Check if the enemy is dead.
        if (currentHealth <= 0)
        {
            // Call the Die function.
            Die();
        }
    }

    // Function for death
    void Die()
    {
        // Destroy the enemy object
        this.gameObject.SetActive(false);

        // Respawn the enemy after 5 seconds
        Invoke("Respawn", 5.0f);
    }

    // Function to respawn the enemy
    void Respawn()
    {
        // Reset enemy's health
        currentHealth = maxHealth;

        // Respawn the enemy
        this.gameObject.SetActive(true);
    }
}
