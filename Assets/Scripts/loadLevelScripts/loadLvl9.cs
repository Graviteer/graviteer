using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadLvl9 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level9()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(9);
    }

}
