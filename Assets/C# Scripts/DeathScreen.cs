using UnityEngine;
using UnityEngine.SceneManagement;

/* DeathScreen.cs
*   Author: Ethan Sowle
*   Description: A class to display death screen.
*   Parametes: None
*   Return: None
*   Date Created: 4/12/2024
*   Date Modified: 4/12/2024
*/

public class DeathScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
