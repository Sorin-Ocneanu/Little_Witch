using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{

    [SerializeField] private GrabObject grab; //to see if the character is in grab mode

    public CharacterController2D controller;
    public float horizontalMove = 0f;
    float runSpeed = 40f;
    private bool jump;  //used to determine if the character should jump
    private bool flip;  //used to determine if the character should flip
    

    // Update is called once per frame
    void Update()
    {
        //calculates the horizontal move (1 or -1) * runSpeed 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && !grab.IsGrabbing)
        {
            jump = true;
        }

        //if the character is grabbing it should not flip
        if (grab.IsGrabbing)
            flip = false;
        else
            flip = true;
    }

    void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump,flip);
        jump = false;
    }

}
