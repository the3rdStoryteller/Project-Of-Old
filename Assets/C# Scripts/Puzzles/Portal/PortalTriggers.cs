using UnityEngine;

/* PortalTriggers.cs
*   Author: Ethan Sowle
*   Description: A class to activate trigger when collided with player.
*   Parametes: None
*   Return: None
*   Date Created: 4/26/2024
*   Date Modified: 4/26/2024
*/

public class PortalTriggers : MonoBehaviour
{
    bool isNotTriggered = true;

    // This method is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player") && isNotTriggered)
        {
            // The player has collided with the trigger
            Debug.Log("Player has collided with the ORB");
            isNotTriggered = false;
            PortalPuzzle.addToActiveTriggers(this);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
