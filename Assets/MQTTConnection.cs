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


public class MQTTConnection : MonoBehaviour
{
    [Header("MQTT Configuration")]
    public string BrokerAddress = "broker.hivemq.com";
    public int BrokerPort = 1883;
	public string username = "";
	public string password = "";
    public string Topic_Angle = "/RigthArm/Elbow/FLEX";

    [Header("Mocap Data")]
    public ValueArmRight  ScriptArmRight;
    public ValueArmLeft   ScriptArmLeft;
    public ValueNeckHead  ScriptHeadNeck;
    public ValuesLeg      ScriptLeg;
    public ValueBack      ScriptBack;


    private MqttClient client;



    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(BrokerAddress, BrokerPort , false , null ); 

       // client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId, username, password);
        client.Subscribe(new string[] {Topic_Angle}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
       // client.Subscribe(new string[] { "M2MQTT_Unity/test" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    
    }

    // Update is called once per frame
    void Update()
    {
        //left arm
        float AngleElbowLeft = ScriptArmLeft.ELbowAngle;
//        client.Publish(Topic_Angle, System.Text.Encoding.UTF8.GetBytes(AngleElbow.ToString()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        float AngleShoulderAbAdLeft = ScriptArmLeft.ShAdAbAngle;
        float AngleShoulderFlExLeft = ScriptArmLeft.ShFlExAngle;
        float AngleLowArmProSupLeft = ScriptArmLeft.lowArmPronateL;
        float AngleUpArmRotLeft = ScriptArmLeft.upArmRotateL;
        float AngleHandFlExLeft =ScriptArmLeft.handFlexL;
        float AngleHandRadDuctLeft = ScriptArmLeft.handRadDuctL;

        //right arm
        float AngleElbowRight = ScriptArmRight.ELbowAngle;
        float AngleShoulderAbAdRight = ScriptArmRight.ShAdAbAngle;
        float AngleShoulderFlExRight = ScriptArmRight.ShFlExAngle;
        float AngleLowArmProSupRight = ScriptArmRight.lowArmPronateR;
        float AngleUpArmRotRight = ScriptArmRight.upArmRotateR;
        float AngleHandFlExRight =ScriptArmRight.handFlexR;
        float AngleHandRadDuctRight = ScriptArmRight.handRadDuctR;
        
        //neck n head
        float AngleNeckFlEx = ScriptHeadNeck.NeckFlExAngle;
        float AngleNeckTors = ScriptHeadNeck.neckTors;
        float AngleNeckBend = ScriptHeadNeck.neckBend;
        float AngleHeadTilt = ScriptHeadNeck.headSideTilt;

        //back
        float AngleTorsoTilt = ScriptBack.torsoTilt;
        float AngleTorsoSideTilt = ScriptBack.torsoSideTilt;
        float AngleBackCurve = ScriptBack.backCurve;
        float AngleBackTors = ScriptBack.backTors;

        //legs
        float AngleLegLeft = ScriptLeg.kneeLAngle;
        float AngleLegRight = ScriptLeg.kneeRAngle;
        
        float[] AllValuesArray = {AngleElbowLeft, AngleShoulderAbAdLeft, AngleShoulderFlExLeft, AngleLowArmProSupLeft, AngleLowArmProSupLeft, AngleUpArmRotLeft, AngleHandFlExLeft, AngleHandRadDuctLeft,
        AngleElbowRight, AngleShoulderAbAdRight, AngleShoulderFlExRight,  AngleLowArmProSupRight, AngleLowArmProSupRight, AngleUpArmRotRight, AngleHandFlExRight, AngleHandRadDuctRight,
        AngleNeckFlEx, AngleNeckTors, AngleNeckBend, AngleHeadTilt,
        AngleTorsoTilt, AngleTorsoSideTilt, AngleBackCurve, AngleBackTors,
        AngleLegLeft, AngleLegRight};
        client.Publish(Topic_Angle, System.Text.Encoding.UTF8.GetBytes(string.Join( " ", AllValuesArray)), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);


    }
}
