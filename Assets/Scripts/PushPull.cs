using UnityEngine;

public class PushPull : MonoBehaviour
{
    public InputReader inputReader;
    public float minRange = 5.0f;
    public float maxRange = 30.0f;
    public float pullSpeed = 10.0f;
    public Transform player;
    public LaserScript laserController;

    GameObject selectedObject;
    float selectDistance;
    public bool isMovingObject = false;

    int layerMask;

    // Start is called before the first frame update
    void OnEnable()
    {
        int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
        int waterLayerMask = 1 << LayerMask.NameToLayer("Water");
        int combinedMask = playerLayerMask | waterLayerMask;
        layerMask = ~combinedMask;

        inputReader.FireEndEvent += StopFiring;
    }

    void OnDisable()
    {
        inputReader.FireEndEvent -= StopFiring;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMovingObject)
        {
            return;
        }

        laserController.RenderLaser();

        Transform affectedTransform = selectedObject.transform;
        Rigidbody2D affectedRigidbody = selectedObject.GetComponent<Rigidbody2D>();

        Vector2 laserStartPos = laserController.transform.position;
        Vector2 laserDirection = laserController.laserDirection;
        Vector3 normalizedLaser = laserStartPos + (laserDirection.normalized * selectDistance);

        // Check if player is between selected object and laser target
        Vector2 objectToPlayer = player.position - affectedTransform.position;
        Vector2 laserToPlayer = player.position - normalizedLaser;

        if (Vector2.Dot(objectToPlayer, laserToPlayer) < 0)
        {
            return;
        }

        Debug.DrawLine(laserStartPos, normalizedLaser, Color.green);

        Vector3 towardsLaser = normalizedLaser - affectedTransform.position;

        Debug.DrawLine(affectedTransform.position, affectedTransform.position + towardsLaser, Color.red);
        affectedRigidbody.MovePosition(affectedTransform.position + towardsLaser * Time.fixedDeltaTime * pullSpeed);
    }



    void StopFiring()
    {
        if (isMovingObject)
        {
            // Drop object if fire button is pressed while moving an object
            selectedObject.GetComponent<PhysicsController>().physicsState = PhysicsState.Dynamic;
            isMovingObject = false;
        }
        else
        {
            // Try to pick up object
            Vector2 laserStartPos = laserController.transform.position;
            Vector2 raycastDirection = laserController.laserDirection;

            RaycastHit2D rayHit = Physics2D.Raycast(laserStartPos, raycastDirection, maxRange, layerMask);
            Debug.DrawLine(laserStartPos, laserStartPos + (raycastDirection * maxRange), Color.white, 10.0f);
            if (rayHit.transform != null && rayHit.transform.GetComponent<PhysicsController>() != null)
            {
                GameObject hitObject = rayHit.transform.gameObject;

                if (hitObject.GetComponent<PhysicsController>().physicsState == PhysicsState.Dynamic)
                {
                    selectedObject = hitObject;
                    selectedObject.GetComponent<PhysicsController>().physicsState = PhysicsState.Ether;

                    selectDistance = Mathf.Clamp((laserStartPos - rayHit.point).magnitude, minRange, maxRange);

                    isMovingObject = true;
                }
            }
        }
    }
}
