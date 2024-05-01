using UnityEngine;

public class FirstPuzzle : MonoBehaviour
{
    private static int activeTriggers;

    void Start() 
    {
        activeTriggers = 0;
    }

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

    public static void ResetActiveTriggers()
    {
        activeTriggers = 0;
    }

}