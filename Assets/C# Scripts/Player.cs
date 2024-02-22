using UnityEngine;

/* Player.cs
*   Author: Ethan Sowle
*   Description: A class to represent a player in the game.
*   Parametes: None
*   Return: None
*   Date Created: 2/6/2024
*   Date Modified: 2/22/2024
*/

public class Player : MonoBehaviour {
    public float speed = 3.0F;
    public float jumpSpeed = 4.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
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
    }
}