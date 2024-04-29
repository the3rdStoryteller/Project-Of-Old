using UnityEngine;
using UnityEngine.SceneManagement;

/* PauseMenu.cs
*   Author: Ethan Sowle
*   Description: A class to represent a pause menu in the game.
*   Parametes: None
*   Return: None
*   Date Created: 4/29/2024
*   Date Modified: 4/29/2024
*/

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    void Start()
    {
        GameIsPaused = false;
    }
    
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == false)
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        Debug.Log("Quitting to main menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}