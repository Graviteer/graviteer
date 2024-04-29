using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public InputReader inputReader;
    public LineRenderer lineRenderer;
    public Transform player;
    public Transform laserBeam;

    [HideInInspector] public Vector2 laserDirection;
    Camera mainCam;

    bool isFiring = false;
    Vector2 mousePosition;

    private void Start()
    {
        mainCam = Camera.main;
        inputReader.LookEvent += GetMousePosition;
        inputReader.FireEvent += StartFiring;
        inputReader.FireEndEvent += StopFiring;
        lineRenderer.enabled = false;
    }

    private void OnDisable()
    {
        inputReader.LookEvent -= GetMousePosition;
        inputReader.FireEvent -= StartFiring;
        inputReader.FireEndEvent -= StopFiring;
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);

        Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(mousePosition);
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float constrainedAngle = ConstrainAngle(angle, player.localScale.x);

        laserDirection = Quaternion.Euler(0, 0, constrainedAngle) * Vector2.right;

        if (isFiring)
        {
            RenderLaser();
        }
    }

    public void RenderLaser()
    {
        int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
        int waterLayerMask = 1 << LayerMask.NameToLayer("Water");
        int combinedMask = playerLayerMask | waterLayerMask;
        int layerMask = ~combinedMask;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, laserDirection, Mathf.Infinity, layerMask);

        if (hit)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {

            lineRenderer.SetPosition(1, (Vector2)transform.position + laserDirection * 100);
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
