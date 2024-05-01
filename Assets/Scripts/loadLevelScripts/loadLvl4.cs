using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadLvl4 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level4()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(4);
    }

}
