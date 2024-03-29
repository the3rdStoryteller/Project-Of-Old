using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationSpeed = 1f; // Speed of rotation
    public float interval = 2f; // Interval between rotations
    private static int activeTriggers = 0;

    void Start()
    {
    
    }

    public static void addToActiveTriggers(MonoBehaviour instance)
    {
        activeTriggers++;
        if (activeTriggers == 1)
        {
            RotatePlatform rotatePlatform = GameObject.FindObjectOfType<RotatePlatform>(); // Create an instance of RotatePlatform
            rotatePlatform.StartCoroutine(rotatePlatform.RotateAtInterval()); // Use the instance to call the RotateAtInterval method
        }
    }

    private IEnumerator RotateAtInterval()
    {
        while (true)
        {
            yield return RotateOverTime(90f); // Rotate 90 degrees
            yield return new WaitForSeconds(interval); // Wait for the interval
        }
    }

    private IEnumerator RotateOverTime(float angle)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);

        for (float t = 0; t < 1; t += Time.deltaTime * rotationSpeed)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        // Ensure the rotation is exactly the end rotation at the end
        transform.rotation = endRotation;
    }
}
