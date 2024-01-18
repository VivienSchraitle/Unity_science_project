using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using System;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mrtkCubePrefab; // Assign the MRTK cube prefab in the Inspector.
    private GameObject instantiatedCube;
    private Boolean rula;
    private Boolean reba;
    public TextMeshPro TextReba;
    public TextMeshPro TextRula;
    private Vector3 location;
    public GameObject canvas;
    private int mode = 2;
    public RadialView view;
    public SolverHandler handler;
    private Vector3 scaler = new Vector3(1,1.26f,0.01f);

    void Start()
    {
        if (mrtkCubePrefab == null)
        {
            Debug.LogError("MRTK Cube Prefab is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case 1:
                setAngle();
                break;
            case 2:
                if (handler.isActiveAndEnabled == false) 
                {
                    handler.enabled = true;
                }
                break;
            case 3:
                
                break;
            case 4:
                
                break;
            case 5:
                
                break;

            default:
                mode = 2;
                if (handler.isActiveAndEnabled == false) 
                {
                    handler.enabled = true;
                }
                break;

        }
        if (handler.isActiveAndEnabled && mode != 2) 
        {
            handler.enabled = false;
        }
        
    }
    public void Spawn() {
        if (instantiatedCube != null)
        {
            Destroy(instantiatedCube);
        }

        // Instantiate a new MRTK cube prefab.
        instantiatedCube = Instantiate(mrtkCubePrefab, Vector3.zero, Quaternion.identity);

        // Add any additional components or logic for cube manipulation here.

        // Example: Make the cube movable.
        var manipulator = instantiatedCube.AddComponent<ObjectManipulator>();
        //manipulator.transform = instantiatedCube.transform;

    }
    public void setREBA() {
        TextReba.text = "REBA" + "\n" +
            "1";
    }
    public void setRULA() {
        TextRula.text = "RULA" + "\n" +
          "1";
    }
    private void setAngle()
    {
       location = Camera.main.transform.position +Camera.main.transform.forward;
       canvas.transform.position = location + Camera.main.transform.up.normalized * (float) -0.2 + Camera.main.transform.right.normalized * (float) 0.6;
       canvas.transform.rotation = Camera.main.transform.rotation;
    }

    public void setMode1() 
    {
        mode =  1;
    }
    public void setMode2()
    {
        mode = 2;
    }
    public void setMode3()
    {
        mode = 3;
    }
    public void setMode4()
    {
        mode = 4;
    }
    public void setMode5()
    {
        mode = 5;
    }
    public void setScale(SliderEventData sliderEventData)
    {
        canvas.transform.localScale = sliderEventData.NewValue * scaler;
    }
    public void test()
    {}
}
