using UnityEngine;

/* FloorTriggers.cs
*   Author: Ethan Sowle
*   Description: A class to detect when the player has collided with a floor trigger.
*   Parametes: None
*   Return: None
*   Date Created: 2/22/2024
*   Date Modified: 2/22/2024
*/

public class FloorTriggers : MonoBehaviour
{
    bool isNotTriggered = true;

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
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
