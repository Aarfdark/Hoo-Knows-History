using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    public GameObject cube;  // assign the cube child in the Inspector
    public static TargetController currentlyTracked; // global reference

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

        // Hide cube at start
        if (cube != null)
            cube.SetActive(false);
    }

    private void OnDestroy()
    {
        if (observer)
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        if (isTracked)
        {
            // Register this as the current tracked target
            currentlyTracked = this;

            // Hide all other cubes
            TargetController[] allTargets = FindObjectsOfType<TargetController>();
            foreach (var target in allTargets)
            {
                if (target != this && target.cube != null)
                    target.cube.SetActive(false);
            }

            // Show this cube automatically
            if (cube != null)
                cube.SetActive(true);

            Debug.Log($"{name} is now tracked and showing its cube.");
        }
        else if (currentlyTracked == this)
        {
            // Unregister and hide cube when tracking is lost
            currentlyTracked = null;
            if (cube != null)
                cube.SetActive(false);

            Debug.Log($"{name} lost tracking and hid its cube.");
        }
    }

    public void ToggleCube()
    {
        if (cube != null)
        {
            cube.SetActive(!cube.activeSelf);
            Debug.Log($"{name} cube toggled to {(cube.activeSelf ? "ON" : "OFF")}");
        }
    }
}