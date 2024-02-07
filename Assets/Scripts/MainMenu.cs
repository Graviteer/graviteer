using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pausebutton;

    public void PlayGame()
    {
        // Load the next scene in the build order
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseButton()
    {
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
    }
}
