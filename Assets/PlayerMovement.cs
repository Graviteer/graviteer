using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool facingRight = true;
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Flip Player based on Mouse Position
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //if mouse position is on the left of player, player is looking right, switch left
        if(mousePos.x < transform.position.x && facingRight)
        {
            flip();
        }
        //if mouse position is on the right of player, player is looking left, switch right

        else if (mousePos.x > transform.position.x && !facingRight)
        {
            flip();
        }
        

    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void FixedUpdate()
    {
        //Character Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); 
        jump = false;
    }



    
}
