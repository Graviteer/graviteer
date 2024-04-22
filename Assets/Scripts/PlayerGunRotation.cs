using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIt : MonoBehaviour
{

    private Camera mainCam;
    public Transform player;
    public InputReader inputReader;
    Vector2 mousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        inputReader.LookEvent += RotateGun;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

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

    void RotateGun(Vector2 mousePosition)
    {
        Vector2 rot = (mainCam.ScreenToWorldPoint(mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

        angle = ConstrainAngle(angle, player.localScale.x);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
