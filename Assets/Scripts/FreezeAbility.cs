using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAbility : MonoBehaviour
{
    public InputReader inputReader;
    public LaserScript laserController;
    public float maxRange = 30.0f;
    public float freezeDuration = 10.0f;
    public float abilityCooldown = 3.0f;
    float currentCooldown = 0.0f;
    
    int layerMask;

    void OnEnable()
    {
        int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
        int waterLayerMask = 1 << LayerMask.NameToLayer("Water");
        int combinedMask = playerLayerMask | waterLayerMask;
        layerMask = ~combinedMask;

        inputReader.FireEvent += FreezeObject;
    }

    void OnDisable()
    {
        inputReader.FireEvent -= FreezeObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0.0f)
        {
            currentCooldown -= Time.deltaTime;
        }

        if (currentCooldown < 0.0f)
        {
            currentCooldown = 0.0f;
        }
    }

    void FreezeObject()
    {
        if (currentCooldown > 0.0f)
        {
            return;
        }

        Vector2 laserStartPos = laserController.transform.position;
        Vector2 raycastDirection = laserController.laserDirection;

        RaycastHit2D rayHit = Physics2D.Raycast(laserStartPos, raycastDirection, maxRange, layerMask);
        Debug.DrawLine(laserStartPos, laserStartPos + (raycastDirection * maxRange), Color.blue, 10.0f);
        if (rayHit.transform != null && rayHit.transform.GetComponent<PhysicsController>() != null)
        {
            GameObject hitObject = rayHit.transform.gameObject;

            if (hitObject.GetComponent<PhysicsController>().physicsState != PhysicsState.Anchored)
            {
                hitObject.GetComponent<PhysicsController>().freezeTime = freezeDuration;
                currentCooldown = abilityCooldown;
            }
        }
    }
}
