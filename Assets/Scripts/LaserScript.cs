using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Transform LaserBeam;
    public Transform player;
    private Camera mainCam;

    private void Start()
    {
        LineRenderer.enabled = false;
        mainCam = Camera.main;
    }

    private void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        layerMask = ~layerMask;

        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float constrainedAngle = ConstrainAngle(angle, player.localScale.x);

        Vector2 finalDirection = Quaternion.Euler(0, 0, constrainedAngle) * Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, finalDirection, Mathf.Infinity, layerMask);

        LineRenderer.SetPosition(0, LaserBeam.position);
        if (Input.GetMouseButton(0))
        {
            LineRenderer.enabled = true;
            if (hit.collider != null)
            {
                LineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                LineRenderer.SetPosition(1, (Vector2)transform.position + finalDirection * 100);
            }
        }
        else
        {
            LineRenderer.enabled = false;
        }
    }
    
    float ConstrainAngle(float angle, float playerDirection)
    {
        if (playerDirection >= 0)
        {
            return Mathf.Clamp(angle, -80, 80);
        }
        else
        {
            angle = (angle <= 0) ? 180 + angle : angle - 180;
            return Mathf.Clamp(angle, -80, 80) + 180;
        }
    }
}
