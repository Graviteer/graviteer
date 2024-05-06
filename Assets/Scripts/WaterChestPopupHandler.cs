using UnityEngine;
using UnityEngine.UI;

public class WaterChestPopupTrigger : MonoBehaviour
{
    public GameObject popupText;
    public GameObject chestImage;

    private bool isOpen = false;
    private bool hasOpened = false;

    private void Start()
    {
        popupText.SetActive(false);
        chestImage.SetActive(false);
        hasOpened = false;
    }

    private void Update()
    {
        if (!isOpen && !hasOpened && popupText.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = true;
            chestImage.SetActive(true);
            hasOpened = true;
        }
        else if (isOpen && (Input.GetKeyDown(KeyCode.E) || !popupText.activeSelf))
        {
            isOpen = false;
            chestImage.SetActive(false);
            popupText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Enter");
            //if (!hasOpened)
            //{
              //  popupText.SetActive(true);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupText.SetActive(false);
            chestImage.SetActive(false);
            isOpen = false;
        }
    }
}
