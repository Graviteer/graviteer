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
    public float freezeTime = 0.0f;
    PhysicsState lastPhysicsState;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody2D>();
        lastPhysicsState = physicsState;
    }

    void Update()
    {
        if (!objectRigidbody)
        {
            return;
        }

        handleFreeze();

        switch (physicsState)
        {
            case PhysicsState.Anchored:
                objectRigidbody.bodyType = RigidbodyType2D.Static;
                break;
            case PhysicsState.Ether:
                objectRigidbody.bodyType = RigidbodyType2D.Dynamic;
                objectRigidbody.gravityScale = 0;
                break;
            case PhysicsState.Dynamic:
                objectRigidbody.bodyType = RigidbodyType2D.Dynamic;
                objectRigidbody.gravityScale = 1;
                break;
        }
    }

    void handleFreeze()
    {
        if (freezeTime > 0.0f)
        {
            if (physicsState != PhysicsState.Anchored)
            {
                lastPhysicsState = physicsState;
                physicsState = PhysicsState.Anchored;
            }

            freezeTime -= Time.deltaTime;
        }

        if (freezeTime <= 0.0f)
        {
            physicsState = lastPhysicsState;
            freezeTime = 0.0f;
        }
    }
}
