using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl6EndChest : MonoBehaviour
{
    public GameObject popupText;
    public GameObject grabEndKey;

    public bool inRange = false;
    public bool obtained = false;
    public Lvl6EndKeyLock EndLock;
    public Lvl6ChestLock chestLock;

    private void Start()
    {
        popupText.SetActive(false);
        grabEndKey.SetActive(false);
        obtained = false;
    }

    private void Update()
    {
        if (chestLock.hasKey == true && Input.GetKey(KeyCode.E) && inRange)
        {
            obtained = true;
            EndLock.hasEndKey = true;
            //Debug.Log("pressed E");
            grabEndKey.SetActive(false);
            popupText.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && obtained == false)
        {
            Debug.Log("Enter");
            inRange = true;
            grabEndKey.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            popupText.SetActive(false);
            inRange = false;
        }
    }
}