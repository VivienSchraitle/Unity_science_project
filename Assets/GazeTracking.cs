using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using System.Collections;
using System;
using Microsoft.MixedReality.Toolkit;
public class GazeTracking : MonoBehaviour
{
    private int gazeCount = 0;
    private float totalGazeDuration = 0.0f;

    private bool isBeingGazed = false;
    private float gazeStartTime = 0.0f;

    [Tooltip("Time threshold for considering a gaze")]
    public float gazeThreshold = 0.5f;

    private void Update()
    {
        if (isBeingGazed)
        {
            // Calculate gaze duration
            float gazeDuration = Time.time - gazeStartTime;
            totalGazeDuration += gazeDuration;

            // Reset gaze timer
            gazeStartTime = Time.time;

            // Increment gaze count
            gazeCount++;

            Debug.Log("Object is being gazed at. Gaze Duration: " + gazeDuration.ToString("F2") + " seconds");
        }
        else
        {
            Debug.Log("Object is not being gazed at.");
        }

        // Reset gaze flag
        isBeingGazed = false;
    }

    private void OnGazeEnter()
    {
        // Start tracking gaze
        isBeingGazed = true;
        gazeStartTime = Time.time;

        Debug.Log("Gaze entered!");
    }

    private void OnGazeExit()
    {
        // Stop tracking gaze
        isBeingGazed = false;

        Debug.Log("Gaze exited!");
    }

    private void OnEnable()
    {
        // Subscribe to gaze events
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(GetComponent<GazeHandler>());
    }

    private void OnDisable()
    {
        // Unsubscribe from gaze events
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityPointerHandler>(GetComponent<GazeHandler>());
    }

    private void OnDestroy()
    {
        // Unsubscribe from gaze events when the object is destroyed
        OnDisable();
    }

    private void OnApplicationQuit()
    {
        // Log statistics when the application is quit
        Debug.Log("Total Gaze Count: " + gazeCount);
        Debug.Log("Total Gaze Duration: " + totalGazeDuration.ToString("F2") + " seconds");

        float averageGazeDuration = gazeCount > 0 ? totalGazeDuration / gazeCount : 0.0f;
        Debug.Log("Average Gaze Duration: " + averageGazeDuration.ToString("F2") + " seconds");

        float totalSessionDuration = Time.time;
        float gazePercentage = totalGazeDuration / totalSessionDuration * 100.0f;
        Debug.Log("Gaze Percentage: " + gazePercentage.ToString("F2") + "%");
    }
}

public class GazeHandler : MonoBehaviour, IMixedRealityPointerHandler
{
    public void OnPointerClicked(MixedRealityPointerEventData eventData) { }

    public void OnPointerDown(MixedRealityPointerEventData eventData) { }

    public void OnPointerUp(MixedRealityPointerEventData eventData) { }

    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }

    public void OnPointerDownSpecific(MixedRealityPointerEventData eventData)
    {
        OnGazeEnter();
    }

    public void OnPointerUpSpecific(MixedRealityPointerEventData eventData)
    {
        OnGazeExit();
    }

    private void OnGazeEnter()
    {
        SendMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
    }

    private void OnGazeExit()
    {
        SendMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);
    }
}