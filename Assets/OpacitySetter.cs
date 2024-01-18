using UnityEngine;
using UnityEngine.UI;

public class OpacitySetter : MonoBehaviour
{
    [Tooltip("Reference to the DistanceCalculator script")]
    public DistanceCalculator distanceCalculator;

    [Tooltip("Reference to the canvas whose opacity will be adjusted")]
    public GameObject targetCanvas;

    [Tooltip("Minimum distance for full opacity")]
    public float minDistance = 0.5f;

    [Tooltip("Maximum distance for zero opacity")]
    public float maxDistance = 3.0f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        // Ensure the necessary components are available
        if (distanceCalculator == null)
        {
            Debug.LogError("DistanceCalculator reference not set. Please assign the DistanceCalculator script in the inspector.");
            return;
        }

        if (targetCanvas == null)
        {
            Debug.LogError("Target Canvas reference not set. Please assign the Canvas in the inspector.");
            return;
        }

        // Get or add CanvasGroup component
        canvasGroup = targetCanvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = targetCanvas.gameObject.AddComponent<CanvasGroup>();
        }
    }

    private void Update()
    {
        // Check if the DistanceCalculator script is available
        if (distanceCalculator != null)
        {
            // Get the distance from the DistanceCalculator
            float distance = distanceCalculator.CalculateDistanceToCanvas(targetCanvas);

            // Adjust opacity based on distance
            float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
            float opacity = 1.0f - normalizedDistance;

            // Set the canvas opacity
            canvasGroup.alpha = opacity;
        }
        else
        {
            Debug.LogError("DistanceCalculator reference is missing. Please assign the DistanceCalculator script in the inspector.");
        }
    }
}