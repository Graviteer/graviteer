using UnityEngine;
using UnityEngine.UI;

public class CaveChestPopupTrigger : MonoBehaviour
{
    public GameObject popupText;

    private bool inRange = false;
    private bool obtained = false;
    public KeyLock keylock;

    private void Start()
    {
        popupText.SetActive(false);
        obtained = false;
    }

    private void Update()
    {
        if (!obtained && Input.GetKeyDown(KeyCode.E) && inRange)
        {
            obtained = true;
            keylock.hasKey = true;
            popupText.SetActive(true);
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
