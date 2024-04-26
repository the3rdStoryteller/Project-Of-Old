using UnityEngine;
using UnityEngine.SceneManagement;

/* ActivatePortal.cs
*   Author: Ethan Sowle
*   Description: A class to activate the portal. 
*   Parametes: None
*   Return: None
*   Date Created: 4/26/2024
*   Date Modified: 4/26/2024
*/

public class ActivatePortal : MonoBehaviour
{
    bool isNotTriggered = true;

    // This method is called to activate the portal
    public void ActivatePortalMethod()
    {
        Debug.Log("Portal Activated");
        gameObject.SetActive(true);
    }

    // This method is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player") && isNotTriggered)
        {
            Debug.Log("Player has entered the portal");
            isNotTriggered = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
