using UnityEngine;

/* CameraFollow.cs
*   Author: Ethan Sowle
*   Description: A class that follows the player in third-person.
*   Parametes: None
*   Return: None
*   Date Created: 4/11/2024
*   Date Modified: 4/11/2024
*/

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float mouseSensitivity = 100.0f;
    [HideInInspector] public Vector3 offset;
    private float xRotation = -45.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerTransform.Rotate(Vector3.up * mouseX);

        // Position the camera behind the player
        offset = new Vector3(-3, 2, 0);

        // Apply player rotation to offset
        offset = playerTransform.rotation * offset;

        Vector3 newPosition = playerTransform.position + offset;
        transform.position = newPosition;

        // Rotate camera to look at player
        transform.LookAt(playerTransform);
        transform.Rotate(-30, 0, 0);
    }
}