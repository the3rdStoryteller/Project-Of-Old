using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* EnemyControl.cs
*   Author: Ethan Sowle
*   Description: A class that controls the enemy's behavior.
*   Parametes: None
*   Return: None
*   Date Created: 2/24/2024
*   Date Modified: 4/09/2024
*/

public class EnemyControl : MonoBehaviour
{
    public Transform player;
    public int maxHealth = 5;
    private int currentHealth;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction vector from the enemy to the player
        Vector3 direction = player.position - transform.position;

        // Normalize the direction (to get a unit vector)
        direction.Normalize();

        // Move the enemy towards the player
        transform.position += speed * Time.deltaTime * direction;
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
        Destroy(this.gameObject);
    }
}
