using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* FloorTriggers.cs
*   Author: Ethan Sowle
*   Description: A class to detect when the player has collided with a floor trigger
*   Parametes: None
*   Return: None
*   Date Created: 2/22/2024
*   Date Modified: 2/22/2024
*/

public class FloorTriggers : MonoBehaviour
{
    bool isNotTriggered = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player") && isNotTriggered)
        {
            // The player has collided with the trigger
            Debug.Log("Player has collided with the trigger");
            isNotTriggered = false;
            TutorialPuzzle.addToActiveTriggers(this);
        }
    }
}
