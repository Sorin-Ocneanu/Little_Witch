using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttashment : MonoBehaviour
{
    private bool isAttashed;
    public Rigidbody2D body;


    // Update is called once per frame
    private void Update()
    {
        attash(Input.GetKeyDown("g"));
    }

    private void LateUpdate()
    {
        if (isAttashed) {
            Vector3 vector = this.body.transform.position;
            vector.z = -8;
            this.transform.position = vector;
        }
    }

    private void attash(bool value)
    {
        if (value)
        {
            if (isAttashed)
            {
                isAttashed = false;
                this.transform.position = new Vector3Int(0, 0, -10);
            }
            else {
                isAttashed = true;
            }
            
        }

    }


}
