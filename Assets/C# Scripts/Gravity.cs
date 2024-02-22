using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Gravity.cs
*   Author: Ethan Sowle
*   Description: A class to apply gravity to objects in the game.
*   Parametes: None
*   Return: None
*   Date Created: 2/22/2024
*   Date Modified: 2/22/2024
*/

public class Gravity : MonoBehaviour
{
    public float gravity = -9.81f; // Gravity force, you can adjust this value
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, gravity, 0)); // Apply gravity force
    }
}
