using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIt : MonoBehaviour
{

    private Camera mainCam;
    public InputReader inputReader;
    Vector2 mousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        inputReader.LookEvent += RotateGun;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RotateGun(Vector2 mousePosition)
    {
        Vector2 rot = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
