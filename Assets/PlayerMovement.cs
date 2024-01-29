using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    CapsuleCollider2D playerCollider;
    float checkOffset = -2.2f;
    float checkRadiusOffset = -1.75f;

    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();

        float colliderWidth = playerCollider.size.x;
        float colliderHeight = playerCollider.size.y;

        float checkRadius = colliderWidth + checkRadiusOffset;

        controller.k_GroundedRadius = checkRadius;
        controller.k_CeilingRadius = checkRadius;

        float ceilingCheckOffset = colliderHeight - (2 * checkRadius) + checkOffset;
        float groundCheckOffset = ceilingCheckOffset * -1;
        controller.m_CeilingCheck.localPosition = new Vector2(playerCollider.offset.x, ceilingCheckOffset);
        controller.m_GroundCheck.localPosition = new Vector2(playerCollider.offset.x, groundCheckOffset);
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
