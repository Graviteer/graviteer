using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public InputReader inputReader;
    public LineRenderer lineRenderer;
    public Transform laserPos;

    bool isFiring = false;
    Vector2 mousePosition;

    private void Start()
    {
        inputReader.LookEvent += GetMousePosition;
        inputReader.FireEvent += StartFiring;
        inputReader.FireEndEvent += StopFiring;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);

        if (isFiring)
        {
            RenderLaser();
        }
    }

    void RenderLaser()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseWorldPos - transform.position);

        if (hit)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            
            lineRenderer.SetPosition(1, mouseWorldPos);
        }
    }

    void StartFiring()
    {
        lineRenderer.enabled = true;
        isFiring = true;
    }

    void StopFiring()
    {
        isFiring = false;
        lineRenderer.enabled = false;
    }

    void GetMousePosition(Vector2 position)
    {
        mousePosition = position;
    }
}
