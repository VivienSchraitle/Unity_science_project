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
    public int mode = 1; 
    private Color orange = new Color(1.0f, 0.5f, 0.0f, 1.0f);
    // Start is called before the first frame update

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
        // suspend execution for 0.1 seconds
        yield return new WaitForSeconds(0.1f);
        CSVReader.UpdateData();
        List<Tuple<string,string>> data = CSVReader.csvData;
        if(mode == 1)
        {        
        if(data[0].Item1=="red"){
        headTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[0].Item1=="orange")
        {
        headTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        headTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[1].Item1=="red"){
        headSideTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[1].Item1=="orange")
        {
        headSideTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        headSideTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[2].Item1=="red"){
        neckTorsion.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[2].Item1=="orange")
        {
        neckTorsion.GetComponent<SpriteRenderer>().color = orange;
        }else{
        neckTorsion.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[3].Item1=="red"){
        neckTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[3].Item1=="orange")
        {
        neckTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        neckTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[4].Item1=="red"){
        bodyTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[4].Item1=="orange")
        {
        bodyTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        bodyTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[5].Item1=="red"){
        bodySideTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[5].Item1=="orange")
        {
        bodySideTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        bodySideTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[6].Item1=="red"){
        backTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[6].Item1=="orange")
        {
        backTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        backTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[7].Item1=="red"){
        backTorsion.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[7].Item1=="orange")
        {
        backTorsion.GetComponent<SpriteRenderer>().color = orange;
        }else{
        backTorsion.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[8].Item1=="red"){
        shoulderAdductionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[8].Item1=="orange")
        {
        shoulderAdductionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderAdductionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[9].Item1=="red"){
        shoulderAdductionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[9].Item1=="orange")
        {
        shoulderAdductionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderAdductionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[10].Item1=="red"){
        shoulderFlexionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[10].Item1=="orange")
        {
        shoulderFlexionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderFlexionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[11].Item1=="red"){
        shoulderFlexionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[11].Item1=="orange")
        {
        shoulderFlexionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderFlexionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[12].Item1=="red"){
        shoulderRotationL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[12].Item1=="orange")
        {
        shoulderRotationL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderRotationL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[13].Item1=="red"){
        shoulderRotationR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[13].Item1=="orange")
        {
        shoulderRotationR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderRotationR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[14].Item1=="red"){
        elbowFlexionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[14].Item1=="orange")
        {
        elbowFlexionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        elbowFlexionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[15].Item1=="red"){
        elbowFlexionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[15].Item1=="orange")
        {
        elbowFlexionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        elbowFlexionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[16].Item1=="red"){
        handflexionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[16].Item1=="orange")
        {
        handflexionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        handflexionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[17].Item1=="red"){
        handflexionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[17].Item1=="orange")
        {
        handflexionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        handflexionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[18].Item1=="red"){
        handRadicalL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[18].Item1=="orange")
        {
        handRadicalL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        handRadicalL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[19].Item1=="red"){
        handRadicalR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[19].Item1=="orange")
        {
        handRadicalR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        handRadicalR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[20].Item1=="red"){
        kneeStand.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[20].Item1=="orange")
        {
        kneeStand.GetComponent<SpriteRenderer>().color = orange;
        }else{
        kneeStand.GetComponent<SpriteRenderer>().color = Color.green;
        }
        }
        else if(mode == 2)
        {
        if(data[0].Item1=="red"||data[1].Item1=="red"){
        headTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[0].Item1=="orange"||data[1].Item1=="orange")
        {
        headTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        headTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[2].Item1=="red"||data[3].Item1=="red"){
        neckTorsion.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[2].Item1=="orange"||data[3].Item1=="orange")
        {
        neckTorsion.GetComponent<SpriteRenderer>().color = orange;
        }else{
        neckTorsion.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[4].Item1=="red"||data[5].Item1=="red"){
        bodyTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[4].Item1=="orange"||data[5].Item1=="orange")
        {
        bodyTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        bodyTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[6].Item1=="red"||data[7].Item1=="red"){
        backTilt.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[6].Item1=="orange"||data[7].Item1=="orange")
        {
        backTilt.GetComponent<SpriteRenderer>().color = orange;
        }else{
        backTilt.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[8].Item1=="red"||data[10].Item1=="red"||data[12].Item1=="red"){
        shoulderAdductionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[8].Item1=="orange"||data[10].Item1=="orange"||data[12].Item1=="orange")
        {
        shoulderAdductionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderAdductionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[9].Item1=="red"||data[11].Item1=="red"||data[13].Item1=="red"){
        shoulderAdductionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[9].Item1=="orange"||data[11].Item1=="orange"||data[13].Item1=="orange")
        {
        shoulderAdductionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        shoulderAdductionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[14].Item1=="red"){
        elbowFlexionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[14].Item1=="orange")
        {
        elbowFlexionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        elbowFlexionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[15].Item1=="red"){
        elbowFlexionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[15].Item1=="orange")
        {
        elbowFlexionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        elbowFlexionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[16].Item1=="red"||data[18].Item1=="red"){
        handflexionL.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[16].Item1=="orange"||data[18].Item1=="orange")
        {
        handflexionL.GetComponent<SpriteRenderer>().color = orange;
        }else{
        handflexionL.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[17].Item1=="red"||data[19].Item1=="red"){
        handflexionR.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[17].Item1=="orange"||data[19].Item1=="orange")
        {
        handflexionR.GetComponent<SpriteRenderer>().color = orange;
        }else{
        handflexionR.GetComponent<SpriteRenderer>().color = Color.green;
        }
                if(data[20].Item1=="red"){
        kneeStand.GetComponent<SpriteRenderer>().color = Color.red;
        }else if(data[20].Item1=="orange")
        {
        kneeStand.GetComponent<SpriteRenderer>().color = orange;
        }else{
        kneeStand.GetComponent<SpriteRenderer>().color = Color.green;
        }
        }
    }
}
