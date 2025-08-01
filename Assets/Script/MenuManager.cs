using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;


    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Reset time scale to normal when returning to main menu
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; // Reset time scale to normal when returning to main menu
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        mainMenu.SetActive(true); // Show the main menu

    }
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        mainMenu.SetActive(false); // Hide the main menu
    }
}
