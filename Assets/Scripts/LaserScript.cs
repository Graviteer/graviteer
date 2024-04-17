using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Transform LaserPos;


    private void Start()
    {
        LineRenderer.enabled = false;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos-transform.position);
        LineRenderer.SetPosition(0, transform.position);
        if (Input.GetMouseButton(0))
        {
            if (hit)
            {
                LineRenderer.enabled = true;
                LineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                LineRenderer.enabled = true;
                LineRenderer.SetPosition(1, mousePos);
            }
        }
        else
        {
            LineRenderer.enabled = false;
        }
            
            
    }
}
