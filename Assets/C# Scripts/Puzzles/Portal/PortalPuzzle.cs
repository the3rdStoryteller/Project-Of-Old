using UnityEngine;

/* PortalPuzzle.cs
*   Author: Ethan Sowle
*   Description: A class to count triggers to activate portal.
*   Parametes: None
*   Return: None
*   Date Created: 4/26/2024
*   Date Modified: 4/26/2024
*/

public class PortalPuzzle : MonoBehaviour
{
    private static int activeTriggers;

    // Start is called before the first frame update
    void Start()
    {
        activeTriggers = 0;
    }

    public static void addToActiveTriggers(MonoBehaviour instance)
    {
        activeTriggers++;
        if (activeTriggers == 2)
        {
            ActivatePortal[] activatePortals = Resources.FindObjectsOfTypeAll<ActivatePortal>(); // Retrieve all instances of ActivatePortal
            ActivatePortal activatePortal = activatePortals[0]; // Get the first instance of ActivatePortal
            activatePortal.ActivatePortalMethod(); // Use the instance to call the ActivatePortalMethod
        }
    }

    public static int getActiveTriggers()
    {
        Debug.Log(activeTriggers);
        return activeTriggers;
    }

    public static void ResetActiveTriggers()
    {
        activeTriggers = 0;
    }
}
