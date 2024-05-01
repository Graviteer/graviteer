using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadLvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }

}
