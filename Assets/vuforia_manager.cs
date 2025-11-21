using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class VuforiaManager : MonoBehaviour
{
    public Button toggleButton;
    public ObserverBehaviour[] imageTargets; // Drag ALL your Image Targets here
    public Slider transparencySlider; // Drag your UI Slider here
    public float alpha = 1.0f;
    
    private GameObject currentTrackedObject; // The currently tracked AR object
    
    void Start()
    {
        toggleButton.onClick.AddListener(ToggleAR);
        
        // Add listener to the slider
        if (transparencySlider != null)
        {
            transparencySlider.onValueChanged.AddListener(delegate { UpdateTransparency(); });
        }
        
        // Subscribe to tracking events for ALL image targets
        foreach (var target in imageTargets)
        {
            if (target != null)
            {
                target.OnTargetStatusChanged += OnTargetStatusChanged;
            }
        }
    }
    
    // Called when ANY Vuforia target's tracking status changes
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            Debug.Log($"Target tracked: {behaviour.name}");
            
            // Get the AR object (the child of the Image Target)
            if (behaviour.transform.childCount > 0)
            {
                GameObject trackedObject = behaviour.transform.GetChild(0).gameObject;
                SetCurrentTrackedObject(trackedObject);
            }
        }
        else if (targetStatus.Status == Status.NO_POSE)
        {
            Debug.Log($"Target lost: {behaviour.name}");
            
            // If the lost target was our current one, clear it
            if (behaviour.transform.childCount > 0 && 
                behaviour.transform.GetChild(0).gameObject == currentTrackedObject)
            {
                currentTrackedObject = null;
                Debug.Log("Current tracked object cleared");
            }
        }
    }
    
    // Helper method to set the currently tracked object
    private void SetCurrentTrackedObject(GameObject newTarget)
    {
        // Only update if it's a different object
        if (currentTrackedObject != newTarget)
        {
            currentTrackedObject = newTarget;
            
            if (currentTrackedObject != null)
            {
                Debug.Log($"Now controlling: {currentTrackedObject.name}");
                
                // Apply the current slider value to the newly tracked object
                if (transparencySlider != null)
                {
                    alpha = transparencySlider.value;
                    UpdateTransparency();
                }
            }
        }
    }
    
    public void GoToHome()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void UpdateTransparency()
    {
        if (currentTrackedObject == null)
        {
            Debug.LogWarning("No object is currently being tracked!");
            return;
        }
        
        Renderer targetRenderer = currentTrackedObject.GetComponent<Renderer>();
        
        if (targetRenderer == null)
        {
            Debug.LogWarning("Tracked object has no Renderer component!");
            return;
        }
        
        // Get the current color
        Color objectColor = targetRenderer.material.color;
        
        // Set the alpha component to the slider's value
        alpha = transparencySlider.value;
        Debug.Log($"Setting alpha to {alpha} for {currentTrackedObject.name}");
        
        // Create new color with updated alpha
        Color newColor = new Color(objectColor.r, objectColor.g, objectColor.b, alpha);
        
        // Apply the new color
        targetRenderer.material.color = newColor;
    }
    
    public void ToggleAR()
    {
        if (currentTrackedObject != null)
        {
            Debug.Log($"Toggling AR object: {currentTrackedObject.name}");
            currentTrackedObject.SetActive(!currentTrackedObject.activeSelf);
        }
        else
        {
            Debug.Log("No object is currently being tracked!");
        }
    }
    
    private void OnDestroy()
    {
        // Unsubscribe from all events when destroyed
        foreach (var target in imageTargets)
        {
            if (target != null)
            {
                target.OnTargetStatusChanged -= OnTargetStatusChanged;
            }
        }
    }
}