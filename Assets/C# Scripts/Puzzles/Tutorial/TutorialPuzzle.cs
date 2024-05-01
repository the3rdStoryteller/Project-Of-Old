using UnityEngine;

/* TutorialPuzzle.cs
*   Author: Ethan Sowle
*   Description: A class to count the amount of triggers to activate the door.
*   Parametes: None
*   Return: None
*   Date Created: 2/22/2024
*   Date Modified: 4/22/2024
*/

public class TutorialPuzzle : MonoBehaviour
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
        if (activeTriggers == 4)
        {
            Door.SlideDoor(instance);
        }
    }

    public static int getActiveTriggers()
    {
        Debug.Log(activeTriggers);
        return activeTriggers;
    }
}
