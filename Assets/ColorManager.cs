using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject shoulderAdduction;
    public GameObject shoulderFlexion;
    public GameObject shoulderRotation;
    public GameObject elbowFlexion;
    public GameObject handflexion;
    public GameObject handRadical;
    public GameObject kneeSit;
    public GameObject kneeStand;
    private Color orange = new Color(1.0f, 0.5f, 0.0f, 1.0f);
    // Start is called before the first frame update
    void Start()
    {
        TotalyNeeded();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TotalyNeeded()
    {
        yield return StartCoroutine("UpdateColorsAtReasonableSpeed");
    }
    IEnumerator UpdateColorsAtReasonableSpeed()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.1f);
        CSVReader.UpdateData();
        List<Tuple<string,string>> data = CSVReader.csvData;
        if(data[0].Item1=="red"){
        headTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[0].Item1=="orange")
        {
        headTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        headTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
