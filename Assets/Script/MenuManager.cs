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
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
    public void Star()
    {
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
    public void Quit()
    {
        Application.Quit();
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Reset time scale to normal when returning to main menu
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; // Reset time scale to normal when returning to main menu
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        mainMenu.SetActive(true); // Show the main menu
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        mainMenu.SetActive(false); // Hide the main menu
        FindAnyObjectByType<SoundManager>().ButtonSound();
    }
}
