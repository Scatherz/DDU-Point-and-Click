using System.Collections;
using System.Collections.Generic;
using M2MqttUnity.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{
    public EventManager eventManager;
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
    public List<LayerMask> layerMasklist;
    Ray ray;

    public static bool rightTime = false;

    void Start()
    {
        followCursor = true;
        startYRotation = transform.eulerAngles.y;

        playerCamera.fieldOfView = zoomedOutFOV;

        Cursor.visible = false;
    }

    void Update()
    {
        ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, zoomedInFOV, zoomedOutFOV);

        if (Physics.Raycast(ray, 100, layerMasklist[0]))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }

        if (Physics.Raycast(ray, 100, layerMasklist[1]) && !eventManager.screenLightsOn)
        {
            eventManager.TurnOnScreenLights();
        }

        if (Physics.Raycast(ray, 100, layerMasklist[2]) && !eventManager.roomLightsOn)
        {
            eventManager.TurnOnLampLight();
        }

        if (Physics.Raycast(ray, 100, layerMasklist[3]) && eventManager.tired)
        {
            eventManager.DrinkCoffee();
        }

        if (Physics.Raycast(ray, 100, layerMasklist[4]))
        {
            Debug.Log("Phone");
            if (phoneInput == "1" && !rightTime)
            {
                eventManager.Jumpscare();
                Debug.Log("jumpscare D:");
            }
            else if(phoneInput == "1" && rightTime)
            {
                Debug.Log("Win :D");
            }
        }

        phoneInput = M2MqttUnityTest.m5Msg;

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

    public void ZoomIn()
    {
        playerCamera.fieldOfView -= zoomTime * Time.deltaTime;
    }

    public void ZoomOut()
    {
        playerCamera.fieldOfView += zoomTime * Time.deltaTime;

    }
}
