using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
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
