using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera playerCamera;
    public float mouseSensitivity;
    float cameraVerticalRotation;
    float cameraHorizontalRotation;
    float startYRotation;
    bool followCursor;

    void Start()
    {
        followCursor = true;
        startYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        if (followCursor)
        {
            FollowCursor();
        }
        
    }

    void FollowCursor()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraHorizontalRotation += mouseX;
        cameraHorizontalRotation = Mathf.Clamp(cameraHorizontalRotation, startYRotation - 35f, startYRotation + 35f);

        transform.localEulerAngles = Vector3.up * cameraHorizontalRotation;

        cameraVerticalRotation -= mouseY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        playerCamera.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
    }

    public void ZoomIn(Transform selectedTransform)
    {
        
    }

    public void ZoomOut()
    {
        
    }
}
