using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;
    public LaserScript laserController;
    public float maxRange = 30.0f;
    public float cooldownSeconds = 1.5f;
    private float currentCooldown = 0;


    private Vector3 grapplePoint;
    public DistanceJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        joint.enabled = false;
        rope.enabled = false;
        currentCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 laserStartPos = laserController.transform.position;
        Vector2 raycastDirection = laserController.laserDirection;

        RaycastHit2D rayHit = Physics2D.Raycast(laserStartPos, raycastDirection, maxRange, grappleLayer);

        if (rayHit.collider != null && Input.GetMouseButtonDown(0) && currentCooldown <= 0)
        {
            currentCooldown = cooldownSeconds;
            grapplePoint = rayHit.point;
            grapplePoint.z = 0;
            joint.connectedAnchor = grapplePoint;
            joint.enabled = true;
            joint.distance = grappleLength;
            rope.SetPosition(0, grapplePoint);
            rope.SetPosition(1, transform.position);
            rope.enabled = true;
        } else {
            currentCooldown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
        }

        // if (rope.enabled == true)
        // {
        //     rope.SetPosition(1, transform.position);
        // }
    }
}
