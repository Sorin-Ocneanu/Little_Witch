using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndMove : MonoBehaviour
{
    
    [SerializeField] private Transform m_RightCheck;				// A position marking where to check for
    [SerializeField] private LayerMask m_WhatIsInteractive;			// A mask determining what objects are interactable objects
    
    private const float k_RightRadius = .7f;
    private bool dockedToObject = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //check if m_RightCheck is assigned in the inspector
        if (m_RightCheck == null)
        {
            Debug.LogError("m_RightCheck is not assigned in the inspector");
            enabled = false;    // disable the current script component
        }
        
        //check if m_WhatIsInteractive is assigned in the inspector
        if (m_WhatIsInteractive.value == 0)
        {
            Debug.LogError("m_WhatIsInteractive is not assigned in the inspector");
            enabled = false;    // disable the current script component
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (DetectInteractiveObjects())
            {
                Debug.Log("Detected F while near a movable object");
                dockedToObject = true;
            }
            
        }

    }

    public void FixedUpdate()
    {

        if (dockedToObject)
        {
            Debug.Log("You are docked");
            dockedToObject = false;
        }
        
    }

// The player is near an interactive object if a circlecast to the RightCheck position hits anything designated as interactive
    private bool DetectInteractiveObjects()
    {
        Collider2D[] interactiveObjects = Physics2D.OverlapCircleAll(m_RightCheck.position, k_RightRadius, m_WhatIsInteractive);
            foreach (Collider2D interactiveObject in interactiveObjects)
            {
                if (interactiveObject.gameObject != gameObject)
                {
                   // Debug.Log("Detected interactive object");
                    return true;
                }
            }
        
        return false;
    }
}
