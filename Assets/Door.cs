using System.Collections;
using UnityEngine;

/* Door.cs
*   Author: Ethan Sowle
*   Description: This class allows the tutorial door to slide down
                  whenever the SlideDoor function is activated.
*   Parametes: None
*   Return: None
*   Date Created: 2/21/2024
*   Date Modified: 2/21/2024
*/

public class Door : MonoBehaviour
{
    public float slideSpeed = 1f;

    /* SlideDoor()
    *   Author: Ethan Sowle
    *   Description: Perforns the StartCoroutine function to slide the door down
    *   Parametes: None
    *   Return: None
    *   Date Created: 2/21/2024
    *   Date Modified: 2/21/2024
    */
    public void SlideDoor()
    {
        StartCoroutine(SlideToGround());
    }

    /* Start()
    *   Author: Ethan Sowle
    *   Description: None
    *   Parametes: None
    *   Return: None
    *   Date Created: 2/21/2024
    *   Date Modified: 2/21/2024
    */
    void Start() {
        
    }

    /* SlideToGround()
    *   Author: Ethan Sowle
    *   Description: Slides the door down to the ground
    *   Parametes: None
    *   Return: IEnumerator
    *   Date Created: 2/21/2024
    *   Date Modified: 2/21/2024
    */
    private IEnumerator SlideToGround()
    {
        while (transform.position.y > 0)
        {
            float newYPosition = Mathf.Max(transform.position.y - slideSpeed * Time.deltaTime, 0);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            yield return null;
        }
    }
}