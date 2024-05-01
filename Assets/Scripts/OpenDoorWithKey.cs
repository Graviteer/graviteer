using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWithKey : MonoBehaviour
{
    MainMenu LevelLoader;
    public GameObject popupText;
    public KeyLock keylock;
    private bool inRange = false;

    void Start()
    {
        LevelLoader = GetComponent<MainMenu>();
        popupText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (keylock.hasKey)
            {
                LevelLoader.PlayGame();
            } else
            {
                popupText.SetActive(true);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupText.SetActive(false);
            inRange = false;
        }
    }
}
