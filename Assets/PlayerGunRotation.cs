using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIt : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    

    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //Gun Movement
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //if(mousePos.x < transform.position.x && facingRight)
        //{
        //   flip();
        //}
        //else if (mousePos.x > transform.position.x && !facingRight)
        //{
        //    flip();
        //}

    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        
    }
}
