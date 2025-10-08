using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class MqttTest : MonoBehaviour
{
    private MqttClient client;

    void Start()
    {
        // Connect to public MQTT broker
        client = new MqttClient("test.mosquitto.org");

        client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

        string clientId = System.Guid.NewGuid().ToString();
        client.Connect(clientId);

        // Subscribe to topic
        client.Subscribe(new string[] { "unity/test" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

        // Publish message
        client.Publish("unity/test", System.Text.Encoding.UTF8.GetBytes("Hello from Unity!"));
    }

    private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        string message = System.Text.Encoding.UTF8.GetString(e.Message);
        Debug.Log("Received message: " + message);
    }

    void OnDestroy()
    {
        if (client != null && client.IsConnected)
        {
            client.Disconnect();
        }
    }
}
