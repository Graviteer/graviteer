using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputReader inputReader;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    private Animator m_Animator;

    float horizontalMove = 0f;
    bool isJumping = false;

    BoxCollider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponent<Animator>();

        inputReader.MoveEvent += HandleMoveInput;
        inputReader.JumpEvent += HandleJumpInput;
        inputReader.JumpEndEvent += HandleJumpInputEnd;
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetBool("IsRunning", horizontalMove != 0);
    }

    void FixedUpdate()
    {
        //Character Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
    }

    void HandleMoveInput(float inputValue)
    {
        horizontalMove = inputValue * runSpeed;
    }

    void HandleJumpInput()
    {
        isJumping = true;
    }

    void HandleJumpInputEnd()
    {
        isJumping = false;
    }
}
