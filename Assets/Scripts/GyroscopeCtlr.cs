using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeCtlr : MonoBehaviour
{
    private bool gyroscopeEnabled;
    private Gyroscope gyroscope;

    private GameObject cameraContainer;
    private Quaternion rotation;

    private void Start()
    {
        CreateGameObjectCameraContainer();

        gyroscopeEnabled = EnableGyroscope();
    }

    private void CreateGameObjectCameraContainer()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
    }

    private bool EnableGyroscope()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);

            return gyroscope.enabled;
        }
        return false;
    }

    private void Update()
    {
        if (gyroscopeEnabled)
        {
            transform.localRotation = gyroscope.attitude * rotation;
        }
    }
}
