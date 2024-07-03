using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{

    public CharacterController2D controller;
    public float horizontalMove = 0f;
    float runSpeed = 40f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        //calculates the horizontal move (1 or -1) * runSpeed 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }

}
