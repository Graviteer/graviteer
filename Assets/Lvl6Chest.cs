using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl6Chest : MonoBehaviour
{
    public GameObject popupText;
    public GameObject grabKey;

    public bool inRange = false;
    public bool obtained = false;
    public TorchLock torchLock;

    private void Start()
    {
        popupText.SetActive(false);
        grabKey.SetActive(false);
        obtained = false;
    }

    private void Update()
    {
        if (obtained == false && Input.GetKey(KeyCode.E) && inRange)
        {
            obtained = true;
            torchLock.hasTorch = true;
            //Debug.Log("pressed E");
            grabKey.SetActive(false);
            popupText.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Enter");
            inRange = true;
            grabKey.SetActive(true);

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