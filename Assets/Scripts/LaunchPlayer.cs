using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchPlayer : MonoBehaviour
{
    public Rigidbody2D player;
    public float forceMagnitude = 500f;
    public float cooldownSeconds = 5f;
    private float currentCooldown = 0;
    public bool beingLaunched = false;
    public bool justLaunched = false;

    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && currentCooldown <= 0) 
        {
            beingLaunched = true;
            justLaunched = true;
            currentCooldown = cooldownSeconds;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            Vector3 directionToMouse = mouseWorldPosition - transform.position;

            Vector3 forceDirection = directionToMouse.normalized;

            player.AddForce(-forceDirection * forceMagnitude);
        }
    }
}
