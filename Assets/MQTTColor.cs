using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using System.Globalization;
using System.IO;


public class MQTTColor : MonoBehaviour
{
    /*
    [Header("MQTT Configuration")]
    public string BrokerAddress = "broker.hivemq.com";
    public int BrokerPort = 1883;
	public string username = "";
	public string password = "";
    public string Topic_Angle = "mqtt-color";

    
    float headTilt;
    float headSideTilt;
    float neckTorsion;
    float neckTilt;
    float bodyTilt;
    float bodySideTilt;
    float backTilt;
    float backTorsion;
    float shoulderAdductionL;
    float shoulderAdductionR;
    float shoulderFlexionL;
    float shoulderFlexionR;
    float shoulderRotationL;
    float shoulderRotationR;
    float elbowFlexionL;
    float elbowFlexionR;
    float handflexionL;
    float handflexionR;
    float handRadicalL;
    float handRadicalR;
    float kneeStand;
    */

    private MqttClient client;
    private float nextActionTime = 0.0f;
    public float period = 0.5f;
    int i = 0;

    public String RawData;
    public string[] RawDataArray;


    // Use this for initialization
    void Start()
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
nfi.NumberDecimalSeparator = ".";

        // create client instance 
        client = new MqttClient("broker.hivemq.com", 1883, false, null);

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId, "", "");

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { "mqtt-color" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {

        //Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));


        RawData = System.Text.Encoding.UTF8.GetString(e.Message);




    }

    // Update is called once per frame
    void Update()
    {



    }
}
