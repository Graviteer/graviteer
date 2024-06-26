using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchPlayer : MonoBehaviour
{
    public Rigidbody2D player;
    [SerializeField] private InputReader inputReader;
    public float forceMagnitude = 1500f;
    public float cooldownSeconds = 2.5f;
    public float minimumLaunchDuration = 0.1f;
    public float launchDuration = 0;
    private float currentCooldown = 0;
    public bool beingLaunched = false;
    public CharacterController2D controller;

    void OnEnable()
    {
        inputReader.FireEvent += Launch;
    }

    void OnDisable()
    {
        inputReader.FireEvent -= Launch;
    }

    void Start()
    {
        beingLaunched = false;
        currentCooldown = 0;
        launchDuration = 0;
    }

    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            launchDuration -= Time.deltaTime;
        }
    }

    void Launch()
    {
        if (currentCooldown > 0 || controller.waterLaunchLock <= 1f)
        {
            return;
        }

        beingLaunched = true;
        currentCooldown = cooldownSeconds;
        launchDuration = minimumLaunchDuration;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        Vector3 forceDirection = directionToMouse.normalized;

        player.AddForce(-forceDirection * forceMagnitude);
    }
}
