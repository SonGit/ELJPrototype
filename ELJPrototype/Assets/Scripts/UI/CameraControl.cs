using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : Singleton<CameraControl>
{
    private Camera camera;

    private Vector3 cameraPositionDefault;
    private Quaternion cameraRotationDefault;

    private float cameraRotationLeft_YLimit = -0.02f;
    private float cameraRotationRight_YLimit = 0.02f;
    private float cameraRotationUp_XLimit = -0.02f;
    private float cameraRotationDown_XLimit = 0.02f;

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
        Input.gyro.enabled = true;
        cameraPositionDefault = camera.transform.position;
        cameraRotationDefault = camera.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetCameraDefault()
    {
        if (camera != null)
        {
            camera.transform.position = cameraPositionDefault;
            camera.transform.rotation = cameraRotationDefault;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GyroscopeInput();
    }


    private void GyroscopeInput()
    {
        Debug.Log("+++++++" + camera.transform.localRotation.x);

        if (camera != null)
        {
            //if (camera.transform.localRotation.y < 0 && camera.transform.localRotation.y < cameraRotationLeft_YLimit)
            //{
            //    camera.transform.localRotation = Quaternion.Euler(0, cameraRotationLeft_YLimit * 100, 0);
            //    camera.transform.Rotate(0, -cameraRotationLeft_YLimit, 0);
            //}

            //if (camera.transform.localRotation.y > 0 && camera.transform.localRotation.y > cameraRotationRight_YLimit)
            //{
            //    camera.transform.localRotation = Quaternion.Euler(0, cameraRotationRight_YLimit * 100, 0);
            //}

            //if (camera.transform.localRotation.x < 0 && camera.transform.localRotation.x < cameraRotationUp_XLimit)
            //{
            //    camera.transform.localRotation = Quaternion.Euler(cameraRotationUp_XLimit * 100, 0 , 0);
            //}

            //if (camera.transform.localRotation.x > 0 && camera.transform.localRotation.x > cameraRotationDown_XLimit)
            //{
            //    camera.transform.localRotation = Quaternion.Euler(cameraRotationDown_XLimit * 100, 0, 0);
            //}


            camera.transform.Rotate(-Input.gyro.rotationRateUnbiased.x * Time.deltaTime * 2f, -Input.gyro.rotationRateUnbiased.y * Time.deltaTime * 2f, 0);
        }

    }
}
