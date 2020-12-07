using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomingCamera : MonoBehaviour
{
    public Camera cam;
    public float fielOfView;
    public void ZoomCamera()
    {
        cam.fieldOfView = fielOfView;
    }

    
}
