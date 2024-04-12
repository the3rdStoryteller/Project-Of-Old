using System.Collections;
using UnityEngine;

/* Player.cs
*   Author: Ethan Sowle
*   Description: A class to represent a player in the game.
*   Parametes: None
*   Return: None
*   Date Created: 2/6/2024
*   Date Modified: 4/11/2024
*/

public class Player : MonoBehaviour {
    public int health = 10;
    public int attackDMG = 3;
    public float attackRange = 1.0f;
    public AudioClip attackSound;
    public AudioClip deathSound;
    public AudioSource audioSource;
    public float speed = 3.0F;
    public float jumpSpeed = 0.5F;
    public float jumpDuration = 0.2f; // The maximum time the player can jump
    private float jumpTimer;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public LayerMask enemyLayers;
    public Vector3 respawnPoint;
    public float respawnYPos = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController and AudioSource components
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        // Set the respawn point to the player's starting position
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player
        // Check if the player is on the ground
        if (controller.isGrounded) 
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Check if the Jump button (spacebar by default) is pressed
            if (Input.GetButton("Jump"))
            {
                // Start the jump timer
                jumpTimer = jumpDuration;
                moveDirection.y = jumpSpeed;
            }
        }
        // Check if the player is in the middle of a jump
        else if (jumpTimer > 0)
        {
            // Continue the jump
            jumpTimer -= Time.deltaTime;
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }
        
        // Apply gravity
        moveDirection.y += Physics.gravity.y * Time.deltaTime;
        
        // Apply movement
        controller.Move(moveDirection * Time.deltaTime);

        // Attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        // Respawn the player if they fall off the map
        if (transform.position.y < respawnYPos)
        {
            Respawn();
        }
    }

    // Function to handle player attacks
    void Attack() 
    {
        // Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider enemy in hitEnemies)
        {
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(attackDMG);
            }
        }

        // Play attack sound
        audioSource.PlayOneShot(attackSound);
    }

    // Function to handle player taking damage
    public void TakeDamage(int damage)
    {
        // Reduce the health by the damage amount.
        health -= damage;

        Debug.Log("Player took " + damage + " damage.");
        Debug.Log("Current health: " + health);

        // Check if the player is dead.
        if (health <= 0)
        {
            // Call the Die function.
            Die();
        }
    }

    // Function to handle player death
    void Die()
    {
        // Play death sound
        audioSource.PlayOneShot(deathSound);

        // Start the DisableAfterDelay coroutine, passing in the length of the death sound
        //StartCoroutine(DisableAfterDelay(deathSound.length));

        // Disable the Player object
        this.gameObject.SetActive(false);

        // Call Respawn function
        Respawn();
    }

    // Coroutine to disable the GameObject after a delay
    /*IEnumerator DisableAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Disable the Player object
        this.gameObject.SetActive(false);

        // Call Respawn function
        Respawn();
    }*/

    // Function to handle player respawning
    void Respawn() 
    {
        // Reset player's health and position
        health = 10;
        transform.position = respawnPoint;

        // Re-enable the Player object
        this.gameObject.SetActive(true);
    }
}