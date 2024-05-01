using UnityEngine;
using UnityEngine.SceneManagement;

/* Player.cs
*   Author: Ethan Sowle
*   Description: A class to represent a player in the game.
*   Parametes: None
*   Return: None
*   Date Created: 2/6/2024
*   Date Modified: 4/26/2024
*/

public class Player : MonoBehaviour {
    public int health = 10;
    public int attackDMG = 3;
    public float attackRange = 1.0f;
    public AudioClip attackSound;
    public AudioClip damageSound;
    public AudioSource audioSource;
    public float speed = 3.0F;
    public float jumpSpeed = 0.5F;
    public float jumpDuration = 0.2f; // The maximum time the player can jump
    private float jumpTimer;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public LayerMask enemyLayers;
    private Vector3 respawnPos;
    private Quaternion respawnRos;
    public float respawnYPos = -10.0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController, AudioSource, and Animator components
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();

        // Set the respawn position to the player's starting position
        respawnPos = transform.position;

        // Set the respawn rotation to the player's starting rotation
        respawnRos = transform.rotation;
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

        // Kill the player if they fall off the map
        if (transform.position.y < respawnYPos)
        {
            Die();
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

        // Play damage sound
        audioSource.PlayOneShot(damageSound);

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
        // Disable the Player object
        this.gameObject.SetActive(false);

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;

        // Reset the active triggers for the puzzles
        PortalPuzzle.ResetActiveTriggers();
        FirstPuzzle.ResetActiveTriggers();

        // Call the death screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function to handle player respawning
    void Respawn() 
    {
        // Reset player's health and position and rotation
        health = 3;
        transform.position = respawnPos;
        transform.rotation = respawnRos;

        // Re-enable the Player object
        this.gameObject.SetActive(true);
    }
}