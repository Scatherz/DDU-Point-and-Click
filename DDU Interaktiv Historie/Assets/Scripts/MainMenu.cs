using System.Collections;
using System.Collections.Generic;
using M2MqttUnity.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public M2MqttUnityTest phone;
    bool isLoadingScenes = false;

    void Update()
    {
        if(M2MqttUnityTest.m5Msg == "1" && !isLoadingScenes)
        {
            SceneManager.LoadScene(1);
            isLoadingScenes = true;
        }
    }
}
