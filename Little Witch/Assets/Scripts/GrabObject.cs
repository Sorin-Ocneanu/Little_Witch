using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GrabObject : MonoBehaviour
{

    [SerializeField] private Transform RightCheck; // A position marking where to check for
    [SerializeField] private LayerMask m_LayerOfMovableObjects; // The layer of the interactable objects
    [SerializeField] private GameObject player;

    private const float k_RightRadius = 1f;    //the radius around the point of interactive object detecion
    public bool F_keyIsPressed;                //used to remember if F key was pressed
    private Vector3 m_OriginPos;
    private GameObject m_interactiveObject;     //used to remember the interactive object 

    // Start is called before the first frame update
    void Start()
    {
        //check if m_RightCheck is assigned in the inspector
        if (RightCheck == null)
        {
            Debug.LogError("m_RightCheck is not assigned in the inspector");
            enabled = false; // disable the current script component
        }

        //check if m_WhatIsInteractive is assigned in the inspector
        if (m_LayerOfMovableObjects.value == 0)
        {
            Debug.LogError("m_WhatIsInteractive is not assigned in the inspector");
            enabled = false; // disable the current script component

        }

    }

    // Update is called once per frame
    void Update()
    {
        //if the F key is pressed 
        if (Input.GetKeyDown(KeyCode.F))
        {
            //check if near an interactive object
            if (DetectInteractiveObjects())
            {
                //toggle the past value of F_keyPressed
                F_keyIsPressed = !F_keyIsPressed;
                
                if (F_keyIsPressed)
                {
                    Debug.Log("Activated F while near a movable object");
                    dockToObject();
                    
                    
                }
                else
                {
                    Debug.Log("Deactivated F while near a movable object");
                    unDockFromObject();
                }
                

            }
            
               
        }
     

    }

    private void dockToObject()
    {
        m_interactiveObject.transform.SetParent(player.transform);

        if (player.transform.localScale.x < 0)
        {
            m_interactiveObject.transform.position = player.transform.position - new Vector3(1.5f, 0.08f);
        }
        else
            m_interactiveObject.transform.position = player.transform.position + new Vector3(1.5f, 0.08f);
        
        Debug.Log("I am docked");
    }

    private void unDockFromObject()
    {
        m_interactiveObject.transform.SetParent(null);
    }




// return true if a circlecast to the RightCheck position hits any object inside the "Interactive Objects" layer
    private bool DetectInteractiveObjects()
    {
        //making the circlecast that detects objects near to it
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(RightCheck.position, k_RightRadius, m_LayerOfMovableObjects);
        
        //take each object detected inside the circlecast 
        foreach (Collider2D detectedObject in detectedObjects)
        {
            //check if the detected object is inside the "Interactive Objects" layer
            //if it is, store it inside m_interactiveObject 
            if (detectedObject.gameObject.CompareTag("Interactive Object"))
            {
                m_interactiveObject = detectedObject.gameObject;
                return true;
            }
        }

        return false;
    }
    
    
}

