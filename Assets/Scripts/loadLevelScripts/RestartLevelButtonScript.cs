using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevelButtonScript : MonoBehaviour
{
    int sceneBuildIndex
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void restartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}