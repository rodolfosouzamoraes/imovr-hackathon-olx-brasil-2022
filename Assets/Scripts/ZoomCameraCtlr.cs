using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCameraCtlr : MonoBehaviour
{
    public int cameraFieldOrigin = 60;
    public int cameraFieldZoonIn = 40;
    private bool isZoonIn = false;

    public void ZoomInOut()
    {
        if(isZoonIn == false)
        {
            isZoonIn = true;
            Camera.main.fieldOfView = cameraFieldZoonIn;
        }
        else
        {
            isZoonIn = false;
            Camera.main.fieldOfView = cameraFieldOrigin;
        }
    }
    
}
