using System.Collections;
using System.Collections.Generic;
using M2MqttUnity.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{
    public M2MqttUnityTest phone;
    public Camera playerCamera;
    public float mouseSensitivity;
    float cameraVerticalRotation;
    float cameraHorizontalRotation;
    float startYRotation;
    public float zoomedInFOV;
    public float zoomedOutFOV;
    public float zoomTime;
    bool followCursor;
    public string phoneInput;
    public LayerMask layerMask;
    Ray ray;

    public static bool rightTime = false;

    void Start()
    {
        followCursor = true;
        startYRotation = transform.eulerAngles.y;

        playerCamera.fieldOfView = zoomedOutFOV;
    }

    void Update()
    {
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
        
        phoneInput = M2MqttUnityTest.m5Msg;

        if (followCursor)
        {
            FollowCursor();
        }

        if (phoneInput == "1" && !rightTime)
        {
            Debug.Log("jumpscare D:");
        }
        else if(phoneInput == "1" && rightTime)
        {
            Debug.Log("Win :D");
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
        playerCamera.fieldOfView -= zoomTime * Time.deltaTime;
    }

    public void ZoomOut()
    {
        playerCamera.fieldOfView += zoomTime * Time.deltaTime;
        
    }
}
