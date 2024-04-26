using UnityEngine;

public class FirstPuzzleTrigger : MonoBehaviour
{
    bool isNotTriggered = true;
   
    // This method is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player") && isNotTriggered)
        {
            // The player has collided with the trigger
            Debug.Log("Player has collided with the Trigger");
            isNotTriggered = false;
            FirstPuzzle.addToActiveTriggers(this);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
