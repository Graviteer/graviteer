using UnityEngine;
using UnityEngine.UI;

public class PopupTrigger : MonoBehaviour
{
    public GameObject popupText;
    public GameObject chestImage;

    private bool isOpen = false;

    private void Start()
    {
        popupText.SetActive(false);
        chestImage.SetActive(false);
    }

    private void Update()
    {
        if (!isOpen && popupText.activeSelf && Input.GetKeyDown(KeyCode.O))
        {
            isOpen = true;
            chestImage.SetActive(true);
        }
        else if (isOpen && (Input.GetKeyDown(KeyCode.O) || !popupText.activeSelf))
        {
            isOpen = false;
            chestImage.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupText.SetActive(true);
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
