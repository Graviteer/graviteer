using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevelCollider : MonoBehaviour
{
    int sceneBuildIndex { 
    get { 
        return SceneManager.GetActiveScene().buildIndex + 1; 
    }
}
    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");
            // Player entered, so move level
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        
    }
}