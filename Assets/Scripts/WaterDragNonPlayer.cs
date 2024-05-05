using UnityEngine;
using System.Collections.Generic;

public class WaterDragNonPlayer : MonoBehaviour
{
    // Variables to control how much to change the drag and gravity when in water
    public float waterDrag = 2.0f;
    public float waterGravityScale = 0.5f;

    // Store initial values to restore them later
    private Dictionary<Rigidbody2D, (float, float)> originalValues = new Dictionary<Rigidbody2D, (float, float)>();

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is not on the Player layer
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Store original drag and gravity values
                if (!originalValues.ContainsKey(rb))
                {
                    originalValues[rb] = (rb.drag, rb.gravityScale);
                }

                // Set drag and gravity values for water-like behavior
                rb.drag = waterDrag;
                rb.gravityScale = waterGravityScale;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Restore original drag and gravity values when leaving the water
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null && originalValues.ContainsKey(rb))
        {
            (float originalDrag, float originalGravityScale) = originalValues[rb];
            rb.drag = originalDrag;
            rb.gravityScale = originalGravityScale;

            // Remove from dictionary after restoring
            originalValues.Remove(rb);
        }
    }
}
