using UnityEngine;
using Vuforia;

public class ImageTargetDetector : MonoBehaviour
{
    public bool isDetected = false;

    private void OnEnable() {
        var observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnDisable() {
        var observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Image Target detected
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
            isDetected = true;
        else
            isDetected = false;
    }
}