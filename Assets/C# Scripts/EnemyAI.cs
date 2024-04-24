using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/* EnemyAI.cs
*   Author: Ethan Sowle
*   Description: A class that controls the enemy's AI behavior.
*   Parametes: None
*   Return: None
*   Date Created: 4/11/2024
*   Date Modified: 4/24/2024
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
    public Vector3 respawnPoint;
    public AudioClip attackSound;
    public AudioClip deathSound;
    public AudioSource audioSource;

    private void Awake()
    {
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Set the respawn point to the enemy's starting position
        respawnPoint = transform.position;
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
            // Check if the player is within attack range
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

    // Function to look at the player
    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    // Function to update path to player
    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            // Get a reference to the NavMeshAgent component
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            // Set the destination to the players's position
            agent.SetDestination(target.position);

            // Update the path every 0.2 seconds
            pathUpdateDeadline = Time.time + pathUpdateDelay;
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

            // Play attack sound
            audioSource.PlayOneShot(attackSound);

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
            // Play death sound
            audioSource.PlayOneShot(deathSound);

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
        // Reset enemy's health and position
        currentHealth = maxHealth;
        transform.position = respawnPoint;
        isAttacking = false;

        // Respawn the enemy
        this.gameObject.SetActive(true);
    }
}
