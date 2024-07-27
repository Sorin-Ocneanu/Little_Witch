using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraAttachment : MonoBehaviour
{
    private bool isAttached;
    public Rigidbody2D mainSubject;


    private void Start()
    {
        if (mainSubject == false)
        {
            mainSubject = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //follows the player with the camera
        Vector3 vector = mainSubject.transform.position;
        //makes sure that the camera is in front of all the layers
        vector.z = -1;
        transform.position = vector;
    }
    
    
   


}
