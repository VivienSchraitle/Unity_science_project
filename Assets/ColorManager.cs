using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Microsoft.MixedReality.Toolkit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;
using Random = System.Random;

public class ColorManager : MonoBehaviour
{
    public GameObject headTilt;
    public GameObject headSideTilt;
    public GameObject neckTorsion;
    public GameObject neckTilt;
    public GameObject bodyTilt;
    public GameObject bodySideTilt;
    public GameObject backTilt;
    public GameObject backTorsion;
    public GameObject shoulderAdductionL;
    public GameObject shoulderAdductionR;
    public GameObject shoulderFlexionL;
    public GameObject shoulderFlexionR;
    public GameObject shoulderRotationL;
    public GameObject shoulderRotationR;
    public GameObject elbowFlexionL;
    public GameObject elbowFlexionR;
    public GameObject handflexionL;
    public GameObject handflexionR;
    public GameObject handRadicalL;
    public GameObject handRadicalR;
    public GameObject kneeStand;

    public TMP_Text textMeshPro; // Reference to the Text Mesh Pro object
    public RectTransform planeRectTransform; // Reference to the RectTransform component of the plane
    public int mode = 1;
    public List<Tuple<string, string>> data;
    private Color orange = new Color(1.0f, 0.5f, 0.0f, 1.0f);
    private bool isUpdatingColors = false;
    // Start is called before the first frame update

    public String[] RawDataArray;
    public MQTTColor MQTTColor;

    private static ColorManager _singleton;
    public static ColorManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"[{nameof(ColorManager)}] Instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    void Start()
    {
        if (!isUpdatingColors)
        {
            StartCoroutine(ContinuousColorUpdate());
        }
    }

    // Update is called once per frame
    private IEnumerator ContinuousColorUpdate()
    {
        isUpdatingColors = true;

        while (isUpdatingColors)
        {
            Debug.Log("starting routine");
            UpdateColorsAtReasonableSpeed();
            yield return new WaitForSeconds(0.2f); // Adjust the delay as needed
        }

        isUpdatingColors = false;
    }

    public void UpdateColorsAtReasonableSpeed()
    {
        data = new List<Tuple<string, string>>();
        char[] helper = new char[1];
        helper[0] = (char)',';
        if (MQTTColor.RawData != "")
        {
            RawDataArray = MQTTColor.RawData.Split(helper);
        }        
        Debug.Log(MQTTColor.RawData);
        Debug.Log(RawDataArray.Length);
        if (RawDataArray.Length> 1)
        {
            Debug.Log("RawDataArray.Length> 1");
            //data formating
            string color;
            if (float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) < 25f && float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) >= 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) < 85 && float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) >= 25f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[0].ToString()));

            if (float.Parse(RawDataArray[1], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[1], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[1].ToString()));

            if (float.Parse(RawDataArray[2], CultureInfo.InvariantCulture.NumberFormat) < 45f && float.Parse(RawDataArray[2], CultureInfo.InvariantCulture.NumberFormat) >= -45f)
            {
                color = "green";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[2].ToString()));

            if (float.Parse(RawDataArray[3], CultureInfo.InvariantCulture.NumberFormat) < 25f && float.Parse(RawDataArray[3], CultureInfo.InvariantCulture.NumberFormat) >= 0f)
            {
                color = "green";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[3].ToString()));
            if (float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) >= 0)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) < 60 && float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) >= 20f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[4].ToString()));
            if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) > -20f && float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) <= -10f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[5].ToString()));
            if (float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) >= 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) < 40f && float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) >= 20f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[6].ToString()));
            if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) < 20 && float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) > -20 && float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) <= -10f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[7].ToString()));
            if (float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) < 0 && float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) >= -20f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) < -20 && float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) >= -60f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[8].ToString()));
            if (float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) < 0 && float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) >= -20f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) < -20 && float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) >= -60f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[9].ToString()));

            if (float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) >= 0)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) >= 20)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[10].ToString()));
            if (float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) >= 0)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) >= 20)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[11].ToString()));

            if (float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) < 30f && float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) >= -15)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) >= 30)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) < -15f && float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) >= -30)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[12].ToString()));
            if (float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) < 30f && float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) >= -15)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) >= 30)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) < -15f && float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) >= -30)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[13].ToString()));
            if (float.Parse(RawDataArray[14], CultureInfo.InvariantCulture.NumberFormat) < 100f && float.Parse(RawDataArray[14], CultureInfo.InvariantCulture.NumberFormat) >= 60)
            {
                color = "green";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[14].ToString()));
            if (float.Parse(RawDataArray[15], CultureInfo.InvariantCulture.NumberFormat) < 100f && float.Parse(RawDataArray[15], CultureInfo.InvariantCulture.NumberFormat) >= 60)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[15], CultureInfo.InvariantCulture.NumberFormat) <= 90)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[15].ToString()));
            if (float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) < 25f && float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) >= -50f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[16].ToString()));
            if (float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) < 25f && float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) >= -50f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[17].ToString()));
            if (float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) < 15f && float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) < -10f && float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[18].ToString()));
            if (float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) < 15f && float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) < -10f && float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[19].ToString()));
            if (float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) < 5f && float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) >= 0)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) >= 5)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[20].ToString()));
            Debug.Log("exiting if");
        }




        // suspend execution for 0.1 seconds



        //Debug.Log("First Entry: " + float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat));
        Debug.Log("I am here");
        if (data.Count < 1) { Debug.Log("data is empty"); } else { Debug.Log(data.Count); }
        
        Debug.Log("I am here");
        if (data.Count > 1)
        {
            if (mode == 1)
            {
                if (data[0].Item1 == "red")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[0].Item1 == "orange")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[1].Item1 == "red")
                {
                    headSideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[1].Item1 == "orange")
                {
                    headSideTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    headSideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[2].Item1 == "red")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[2].Item1 == "orange")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[3].Item1 == "red")
                {
                    neckTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[3].Item1 == "orange")
                {
                    neckTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    neckTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[4].Item1 == "red")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[4].Item1 == "orange")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[5].Item1 == "red")
                {
                    bodySideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[5].Item1 == "orange")
                {
                    bodySideTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    bodySideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[6].Item1 == "red")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[6].Item1 == "orange")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[7].Item1 == "red")
                {
                    backTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[7].Item1 == "orange")
                {
                    backTorsion.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    backTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[8].Item1 == "red")
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[8].Item1 == "orange")
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[9].Item1 == "red")
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[9].Item1 == "orange")
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[10].Item1 == "red")
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[10].Item1 == "orange")
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[11].Item1 == "red")
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[11].Item1 == "orange")
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[12].Item1 == "red")
                {
                    shoulderRotationL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[12].Item1 == "orange")
                {
                    shoulderRotationL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderRotationL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[13].Item1 == "red")
                {
                    shoulderRotationR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[13].Item1 == "orange")
                {
                    shoulderRotationR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderRotationR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[14].Item1 == "red")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[14].Item1 == "orange")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[15].Item1 == "red")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[15].Item1 == "orange")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[16].Item1 == "red")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[16].Item1 == "orange")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[17].Item1 == "red")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[17].Item1 == "orange")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[18].Item1 == "red")
                {
                    handRadicalL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[18].Item1 == "orange")
                {
                    handRadicalL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handRadicalL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[19].Item1 == "red")
                {
                    handRadicalR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[19].Item1 == "orange")
                {
                    handRadicalR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handRadicalR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[20].Item1 == "red")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[20].Item1 == "orange")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
            }
            else if (mode == 2)
            {
                if (data[0].Item1 == "red" || data[1].Item1 == "red")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[0].Item1 == "orange" || data[1].Item1 == "orange")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[2].Item1 == "red" || data[3].Item1 == "red")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[2].Item1 == "orange" || data[3].Item1 == "orange")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[4].Item1 == "red" || data[5].Item1 == "red")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[4].Item1 == "orange" || data[5].Item1 == "orange")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[6].Item1 == "red" || data[7].Item1 == "red")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[6].Item1 == "orange" || data[7].Item1 == "orange")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[8].Item1 == "red" || data[10].Item1 == "red" || data[12].Item1 == "red")
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[8].Item1 == "orange" || data[10].Item1 == "orange" || data[12].Item1 == "orange")
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[9].Item1 == "red" || data[11].Item1 == "red" || data[13].Item1 == "red")
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[9].Item1 == "orange" || data[11].Item1 == "orange" || data[13].Item1 == "orange")
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[14].Item1 == "red")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[14].Item1 == "orange")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[15].Item1 == "red")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[15].Item1 == "orange")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[16].Item1 == "red" || data[18].Item1 == "red")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[16].Item1 == "orange" || data[18].Item1 == "orange")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[17].Item1 == "red" || data[19].Item1 == "red")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[17].Item1 == "orange" || data[19].Item1 == "orange")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[20].Item1 == "red")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[20].Item1 == "orange")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                data = null;
            }
            else if (mode == 3)
            {
                String text = "";
                if (data[0].Item1 == "red")
                {
                    text = text + "adjust forward head tilt \n";
                }

                if (data[1].Item1 == "red")
                {
                    text = text + "adjust sidewise head tilt \n";
                }
                if (data[2].Item1 == "red")
                {
                    text = text + "adjust neck torsion \n";
                }
                if (data[3].Item1 == "red")
                {
                    text = text + "adjust neck tilt \n";
                }
                if (data[4].Item1 == "red")
                {
                    text = text + "adjust body forward tilt \n";
                }
                if (data[5].Item1 == "red")
                {
                    text = text + "adjust body side tilt \n";
                }
                if (data[6].Item1 == "red")
                {
                    text = text + "adjust back tilt \n";
                }
                if (data[7].Item1 == "red")
                {
                    text = text + "adjust back torsion \n";
                }
                if (data[8].Item1 == "red")
                {
                    text = text + "adjust left shoulder adduction\n";
                }
                if (data[9].Item1 == "red")
                {
                    text = text + "adjust right shoulder adduction\n";
                }
                if (data[10].Item1 == "red")
                {
                    text = text + "adjust left shoulder flexsation\n";
                }
                if (data[11].Item1 == "red")
                {
                    text = text + "adjust right shoulder flexsation\n";
                }
                if (data[12].Item1 == "red")
                {
                    text = text + "adjust left shoulder rotation\n";
                }
                if (data[13].Item1 == "red")
                {
                    text = text + "adjust right shoulder rotation\n";
                }
                if (data[14].Item1 == "red")
                {
                    text = text + "adjust left elbow flexsation\n";
                }
                if (data[15].Item1 == "red")
                {
                    text = text + "adjust right elbow flexsation\n";
                }
                if (data[16].Item1 == "red")
                {
                    text = text + "adjust left hand flexsation\n";
                }
                if (data[17].Item1 == "red")
                {
                    text = text + "adjust right hand flexsation\n";
                }
                if (data[18].Item1 == "red")
                {
                    text = text + "adjust left hand twist\n";
                }
                if (data[19].Item1 == "red")
                {
                    text = text + "adjust right hand twist\n";
                }
                if (data[20].Item1 == "red")
                {
                    text = text + "adjust standing position\n";
                }
                textMeshPro.text = text;
                Vector2 textSize = textMeshPro.GetRenderedValues(false);
                planeRectTransform.sizeDelta = new Vector2(textSize.x, textSize.y);
            }
        }
    }
}
