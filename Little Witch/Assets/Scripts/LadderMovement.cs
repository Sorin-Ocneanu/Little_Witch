using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float inputVertical;
    private bool isLadder;
    private bool isClimbing;
    private CharacterController2D groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        if (isLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                inputVertical = 1f;  // Move up
                
                    isClimbing = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                inputVertical = -1f;  // Move down
                    isClimbing = true;
            }
            else
            {
                inputVertical = 0f;  // Stay in place

            }

            if (isClimbing)
            {
                rb.gravityScale = 0f;  // Disable gravity while climbing
            }
        }
        else
        {
            isClimbing = false;
            inputVertical = 0f;
            rb.gravityScale = 2f;  // Enable gravity when not climbing
        }
    }

    void FixedUpdate()
    {
        if (isClimbing && groundCheck.m_Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);  
        }
        else if(isClimbing)
        {
            rb.velocity = new Vector2(0, inputVertical * speed);  // Move only vertically
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            rb.gravityScale = 2f;  // Enable gravity when leaving the ladder

            // Ensure the vertical velocity is reset to prevent sticking to the ladder
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y > 0 ? rb.velocity.y : 0);
        }
    }
}
