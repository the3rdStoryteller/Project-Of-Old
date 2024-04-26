using System.Collections;
using UnityEngine;

public class RaisingPlatform : MonoBehaviour
{
    public static float slideSpeed = 1f;
    public Transform[] platforms; // Assign in Inspector
    public float[] targetHeights; // Assign in Inspector

    public void RaisePlatforms(MonoBehaviour instance)
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            instance.StartCoroutine(RaiseToHeight(platforms[i], targetHeights[i]));
        }
    }

    private IEnumerator RaiseToHeight(Transform platform, float targetHeight)
    {
        while (platform.position.y < targetHeight)
        {
            float newYPosition = Mathf.Min(platform.position.y + slideSpeed * Time.deltaTime, targetHeight);
            platform.position = new Vector3(platform.position.x, newYPosition, platform.position.z);
            yield return null;
        }
    }
}
