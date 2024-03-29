using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzleTrigger : MonoBehaviour
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
            Debug.Log("Player has collided with the Trigger");
            isNotTriggered = false;
            FirstPuzzle.addToActiveTriggers(this);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
