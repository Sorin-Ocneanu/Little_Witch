using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttashment : MonoBehaviour
{
    public Camera camera;


    // Update is called once per frame
    private void FixedUpdate()
    {
        attash(Input.GetKeyDown(KeyCode.G));
    }

    private void attash(bool value)
    {
        if (value)
        {
            if (this.camera.transform.parent == null) {
                Vector3 vector = this.transform.position;
                vector.z = -4;
                this.camera.transform.parent = this.transform;
                this.camera.transform.position = vector;
            }
            else
            {
                this.camera.transform.position = new Vector3Int(0, 0, -10);
                this.camera.transform.parent = null;
            }
            
        }

    }
}
