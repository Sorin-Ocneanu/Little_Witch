using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float inputVertical;
    private bool isLadder;
    private bool isClimbing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.gravityScale = 1f;  // Enable gravity when not climbing
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.velocity = new Vector2(0, inputVertical * speed);  // Move only vertically

            if (inputVertical == 0f)
            {
                rb.velocity = new Vector2(0, 0);  // Stay fixed when no vertical input
            }
        }
        else
        {
            float inputHorizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);  // Allow horizontal movement when not climbing
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
            rb.gravityScale = 1f;  // Enable gravity when leaving the ladder
        }
    }
}
