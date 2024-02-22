using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static float slideSpeed = 1f;
    private static Transform trans;

    public static void SlideDoor(MonoBehaviour instance)
    {
        instance.StartCoroutine(SlideToGround());
    }

    // Start is called before the first frame update
    void Start() {
        trans = GetComponent<Transform> ();
    }

    private static IEnumerator SlideToGround()
    {
        while (trans.position.y > 0)
        {
            float newYPosition = Mathf.Max(trans.position.y - slideSpeed * Time.deltaTime, 0);
            trans.position = new Vector3(trans.position.x, newYPosition, trans.position.z);
            yield return null;
        }
    }
}
