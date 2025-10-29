using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour
{
    public Player player;
    void OnMouseEnter()
    {
        player.ZoomIn();
    }

    void OnMouseExit()
    {
        player.ZoomOut();
    }
}
