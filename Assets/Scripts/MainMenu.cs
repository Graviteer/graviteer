using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayGame();
        }
    }
    public void PlayGame()
    {
        // Load the next scene in the build order
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("Quit");
        Application.Quit();
    }
}
