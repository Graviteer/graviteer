using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float checkOffset = 0.5f;
    float horizontalMove = 0f;
    bool jump = false;

    void Start()
    {
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        float colliderWidth = collider.size.x;
        float colliderHeight = collider.size.y;

        controller.k_GroundedRadius = colliderWidth;
        controller.k_CeilingRadius = colliderWidth;

        float ceilingCheckOffset = colliderHeight - (2 * colliderWidth) + checkOffset;
        float groundCheckOffset = ceilingCheckOffset * -1;
        controller.m_CeilingCheck.localPosition = new Vector2(collider.offset.x, ceilingCheckOffset);
        controller.m_GroundCheck.localPosition = new Vector2(collider.offset.x, groundCheckOffset);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //Character Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); 
        jump = false;
    }
}
