using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/* TutorialPuzzle.cs
*   Author: Ethan Sowle
*   Description: A class to count the amount of triggers to activate the door
*   Parametes: None
*   Return: None
*   Date Created: 2/22/2024
*   Date Modified: 2/22/2024
*/

public class TutorialPuzzle : MonoBehaviour
{
    private static int activeTriggers = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
