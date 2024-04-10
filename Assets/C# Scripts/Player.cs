using UnityEngine;

/* Player.cs
*   Author: Ethan Sowle
*   Description: A class to represent a player in the game.
*   Parametes: None
*   Return: None
*   Date Created: 2/6/2024
*   Date Modified: 2/25/2024
*/

public class Player : MonoBehaviour {
    public int health = 10;
    public int attackDMG = 3;
    public float attackRange = 2.0f;
    public float speed = 3.0F;
    public float jumpSpeed = 4.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player
        if (controller.isGrounded) // Check if the player is on the ground
        {
            moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump")) // Check if the Jump button (spacebar by default) is pressed
            {
                moveDirection.y = jumpSpeed; // Apply an upward force
            }
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime; // Apply gravity
        controller.Move(moveDirection * Time.deltaTime);

        // Attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack() 
    {
        // Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);
        //Debug.Log(transform.position);
        //Debug.Log(attackRange);
        //Debug.Log(enemyLayers);

        // Damage them
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.TryGetComponent<EnemyControl>(out var enemyControl))
            {
                enemyControl.TakeDamage(attackDMG);
            }
        }
    }
}