using System.Collections;
using UnityEngine;

/* Door.cs
*   Author: Ethan Sowle
*   Description: A class to lower the door when the player activates
*      four floor triggers. 
*   Parametes: None
*   Return: None
*   Date Created: 2/21/2024
*   Date Modified: 2/22/2024
*/

public class Door : MonoBehaviour
{
    public static float slideSpeed = 1.0f;
    public static float maxYPos = -3.0f;
    private static Transform trans;

    public static void SlideDoor(MonoBehaviour instance)
    {
        instance.StartCoroutine(SlideToGround());
    }

    // Start is called before the first frame update
    void Start() 
    {
        trans = GetComponent<Transform> ();
    }

    private static IEnumerator SlideToGround()
    {
        while (trans.position.y > maxYPos)
        {
            float newYPosition = Mathf.Max(trans.position.y - slideSpeed * Time.deltaTime, maxYPos);
            trans.position = new Vector3(trans.position.x, newYPosition, trans.position.z);
            yield return null;
        }
    }
}
