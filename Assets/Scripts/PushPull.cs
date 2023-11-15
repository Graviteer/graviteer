using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    public GameObject affectedObject;
    public float pushForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rigidbody2D rigidbody = affectedObject.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                float mass = rigidbody.mass;
                rigidbody.AddForce((affectedObject.transform.position - transform.position).normalized * pushForce * mass);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Rigidbody2D rigidbody = affectedObject.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                float mass = rigidbody.mass;
                rigidbody.AddForce((affectedObject.transform.position - transform.position).normalized * -pushForce * mass);
            }
        }
    }
}
