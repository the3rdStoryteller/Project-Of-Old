using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CameraControl.cs
*   Author: Ethan Sowle
*   Description: A class to follow the mouse movement.
*   Parametes: None
*   Return: None
*   Date Created: 2/22/2024
*   Date Modified: 2/22/2024
*/

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public Transform playerBody;

    private float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 90f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
