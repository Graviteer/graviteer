using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LvlResetCollider : MonoBehaviour
{
    int sceneBuildIndex { 
    get { 
        return SceneManager.GetActiveScene().buildIndex; 
    }
}
    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");
            // Player entered, so reset lvl
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        
    }
}