using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadLvl7 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level7()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(7);
    }

}
