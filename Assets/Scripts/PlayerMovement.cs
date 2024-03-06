using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    private Animator m_Animator;

    float horizontalMove = 0f;
    bool jump = false;

    BoxCollider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButton("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            m_Animator.SetBool("IsRunning", true);
        }
        else
        {
            m_Animator.SetBool("IsRunning", false);
        }
    }


    void FixedUpdate()
    {
        //Character Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }


}
