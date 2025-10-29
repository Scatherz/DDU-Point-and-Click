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
    public float zoomedInFOV;
    public float zoomedOutFOV;
    public float zoomTime;
    bool followCursor;
    bool isZoomedIn = false;
    public string phoneInput;

    public LayerMask layerMask;

    Ray ray;

    void Start()
    {
        followCursor = true;
        startYRotation = transform.eulerAngles.y;

        playerCamera.fieldOfView = zoomedOutFOV;
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

        ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, zoomedInFOV, zoomedOutFOV);
        if (Physics.Raycast(ray, 100, layerMask))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
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

    public void ZoomIn()
    {
        Debug.Log("Zoom In");
        playerCamera.fieldOfView -= zoomTime * Time.deltaTime;
    }

    public void ZoomOut()
    {
        Debug.Log("Zoom out");
        playerCamera.fieldOfView += zoomTime * Time.deltaTime;
        
    }
}
