using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadLvl5 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level5()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(5);
    }

}
