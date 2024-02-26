using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    public LayerMask movementCheckLayer;
    public bool isColliding = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.IsTouchingLayers(movementCheckLayer))
        {
            return;
        }

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y >= 0.5)
            {
                isColliding = true;
                return;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
