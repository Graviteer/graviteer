using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

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
    public void freezeGameTime()
    {   
        Time.timeScale = 0f;
    }
    public void resumeGameTime()
    {
        Time.timeScale = 1.0f;
    }
}
