using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzle : MonoBehaviour
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
        if (activeTriggers == 3)
        {
            RaisingPlatform raisingPlatform = GameObject.FindObjectOfType<RaisingPlatform>(); // Create an instance of RaisingPlatform
            raisingPlatform.RaisePlatforms(instance); // Use the instance to call the RaisePlatforms method
        }
    }

    public static int getActiveTriggers()
    {
        Debug.Log(activeTriggers);
        return activeTriggers;
    }

}