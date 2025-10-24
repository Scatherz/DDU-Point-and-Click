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
    public string phoneInput;

    public LayerMask layerMask;

    Ray ray;

    void Start()
    {
        followCursor = true;
        startYRotation = transform.eulerAngles.y;

        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    }

    void Update()
    {
        if (followCursor)
        {
            FollowCursor();
        }

        if (phoneInput == "1")
        {

        }
        else if (phoneInput == "0")
        {

        }
        
        if(Physics.Raycast(ray, out RaycastHit hit, 10, layerMask))
        {
            
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
