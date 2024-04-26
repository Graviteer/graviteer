using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhysicsState
{
    Anchored,
    Ether,
    Dynamic
}

public class PhysicsController : MonoBehaviour
{
    public PhysicsState physicsState;
    public Rigidbody2D objectRigidbody;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!objectRigidbody)
        {
            return;
        }

        switch (physicsState)
        {
            case PhysicsState.Anchored:
                objectRigidbody.bodyType = RigidbodyType2D.Static;
                break;
            case PhysicsState.Ether:
                objectRigidbody.bodyType = RigidbodyType2D.Dynamic;
                objectRigidbody.velocity = new Vector2(objectRigidbody.velocity.x, 0.0f);
                break;
            case PhysicsState.Dynamic:
                objectRigidbody.bodyType = RigidbodyType2D.Dynamic;
                break;
        }
    }
}
