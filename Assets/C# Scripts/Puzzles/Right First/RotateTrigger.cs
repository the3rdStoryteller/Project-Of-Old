using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    bool isNotTriggered = true;

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player") && isNotTriggered)
        {
            // The player has collided with the trigger
            Debug.Log("Player has collided with the TRIGGER");
            isNotTriggered = false;
            RotatePlatform.addToActiveTriggers(this);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
