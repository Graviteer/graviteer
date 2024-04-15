using UnityEngine;

public class PushPull : MonoBehaviour
{
    Camera mainCamera;
    GameObject lastAffectedObject;
    public float pushForce;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastAffectedObject = null;
        }

        if (Input.GetMouseButton(0))
        {
            moveObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (lastAffectedObject != null)
            {
                lastAffectedObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
        }
    }

    public void moveObject()
    {
        if (lastAffectedObject != null)
        {
            lastAffectedObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        Vector3 cursorPos = mainCamera.ScreenToWorldPoint(Input.mousePosition + (Vector3.forward * 10));
        Vector3 raycastDirection = Vector3.forward * 10;
        
        RaycastHit2D rayHit = Physics2D.Raycast(cursorPos - (Vector3.forward * 10), raycastDirection);
        
        if (rayHit.transform != null && rayHit.transform.CompareTag("RayCastDetectable"))
        {
            GameObject hitObject = rayHit.transform.gameObject;

            if (hitObject.GetComponent<Rigidbody2D>() != null)
            {
                lastAffectedObject = hitObject;
            }
        }

        if (lastAffectedObject != null)
        {
            Transform affectedTransform = lastAffectedObject.transform;
            Rigidbody2D affectedRigidbody = lastAffectedObject.GetComponent<Rigidbody2D>();

            //affectTransform.position = cursorPos;
            affectedRigidbody.gravityScale = 0.0f;
            affectedRigidbody.velocity = Vector3.zero;

            Vector3 towardsCursor = cursorPos - affectedTransform.position;
            affectedRigidbody.MovePosition(affectedTransform.position + towardsCursor * Time.deltaTime * pushForce);
        }
    }
}
