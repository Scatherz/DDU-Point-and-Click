using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using M2MqttUnity.Examples;
using UnityEngine;

public class GhostObjects : MonoBehaviour
{
    public void StartCheck()
    {
        Player.rightTime = true;
    }
    
    public void StopCheck()
    {
        Player.rightTime = false;
    }
    
}
