using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlyingEnemy : MonoBehaviour
{
    public PlayerAtributes speedOfPlayer;
    
    private GameObject player;
    
    public float speedMultiplier = 1.25f;  // 25% speed increase for the enemy reported to player speed 
    public float movementSmoothing = 0.05f; // Smoothness factor

    private bool goTowardsPlayer;
    
    private Rigidbody2D enemyRigidbody;
    private Vector3 velocity = Vector3.zero;


    
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (enemyRigidbody == null)
        {
            enemyRigidbody = GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goTowardsPlayer)
        {
            MoveTowardsPlayer();
        }
    }


    private void MoveTowardsPlayer()
    {
        //Calculate the direction towards the player
        Vector2 direction = (player.transform.position - transform.position).normalized;
        
        // Calculate the target velocity
        Vector2 targetVelocity = direction * (speedOfPlayer.runSpeed * speedMultiplier * Time.fixedDeltaTime);
        
        // Smooth the transition between the current velocity and the target velocity
        enemyRigidbody.velocity = Vector3.SmoothDamp(
            enemyRigidbody.velocity, 
            targetVelocity, 
            ref velocity, 
            movementSmoothing
        );
    }

    //checks if the object in the trigger collider is the player
    private void OnTriggerEnter2D(Collider2D colliderEntered)
    {
        if (colliderEntered.gameObject.CompareTag("Player"))
        {
            goTowardsPlayer = true;
        }
    }

   
}
