using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIt : MonoBehaviour
{
    private Camera mainCam;
    public Transform player;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector2 direction = (mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = ConstrainAngle(angle, player.localScale.x);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
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
