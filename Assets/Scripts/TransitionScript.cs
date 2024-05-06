using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    MainMenu LevelLoader;
    // Start is called before the first frame update
    void Start()
    {
        LevelLoader = GetComponent<MainMenu>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            LevelLoader.PlayGame();
        }
    }

}
