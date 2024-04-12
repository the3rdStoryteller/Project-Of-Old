using UnityEngine;
using UnityEngine.SceneManagement;

/* MainMenu.cs
*   Author: Ethan Sowle
*   Description: A class to change scenes in the game.
*   Parametes: None
*   Return: None
*   Date Created: 4/12/2024
*   Date Modified: 4/12/2024
*/

public class MainMenu : MonoBehaviour
{
    public void Play()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
