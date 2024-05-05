using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource FootStepsSand;
    public MovementCheck groundCheck;
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && groundCheck.isColliding)
        {
            FootStepsSand.enabled = true;
        }
        else
        {
            FootStepsSand.enabled = false;
        }
    }
}