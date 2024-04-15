using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D dogRigidbody;
    public float jumpStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            dogRigidbody.velocity = Vector2.up * jumpStrength;
        }
 
    }
}
