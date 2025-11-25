using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    public GameObject cube;  
    public TargetNarration narration;   // <-- ADD THIS

    public static TargetController currentlyTracked;

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

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
        bool reallyTracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        bool reallyLost =
            status.Status == Status.NO_POSE;

        if (reallyTracked)
        {
            // update narration visibility
            if (narration != null)
                narration.targetVisible = true;

            // hide other cubes
            currentlyTracked = this;
            HideOtherCubes();

            if (cube != null)
                cube.SetActive(true);

            Debug.Log($"{name} FOUND");
        }
        else if (reallyLost)
        {
            if (narration != null)
                narration.targetVisible = false;

            if (cube != null)
                cube.SetActive(false);

            if (currentlyTracked == this)
                currentlyTracked = null;

            Debug.Log($"{name} LOST");
        }
    }

    void HideOtherCubes()
    {
        var all = FindObjectsOfType<TargetController>();
        foreach (var t in all)
        {
            if (t != this && t.cube != null)
                t.cube.SetActive(false);
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