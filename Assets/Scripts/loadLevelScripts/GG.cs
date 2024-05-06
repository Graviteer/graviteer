using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GG : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");
            // Player entered, so move level
            SceneManager.LoadScene(0);
        
    }
}