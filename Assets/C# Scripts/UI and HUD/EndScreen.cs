using UnityEngine;
using UnityEngine.SceneManagement;

/* EndScreen.cs
*   Author: Ethan Sowle
*   Description: A class to display credits and end screen.
*   Parametes: None
*   Return: None
*   Date Created: 4/26/2024
*   Date Modified: 4/26/2024
*/

public class EndScreen : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
