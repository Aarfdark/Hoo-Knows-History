using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VuforiaManager : MonoBehaviour
{
    public Button toggleButton;
    public Renderer targetRenderer; // Drag your object here in the Inspector
    public Slider transparencySlider; // Drag your UI Slider here

    void Start()
    {
        TargetController.currentlyTracked.ToggleCube();
        toggleButton.onClick.AddListener(ToggleAR);
    }
    
    public void GoToHome(){
        SceneManager.LoadScene("MenuScene");
    }

    public void UpdateTransparency()
    {
        targetRenderer = TargetController.currentlyTracked;
        Color objectColor = targetRenderer.material.color;
        // Set the alpha (A) component of the color to the slider's value
        objectColor.a = transparencySlider.value;
        targetRenderer.material.color = objectColor;
    }


    public void ToggleAR()
    {
        if (TargetController.currentlyTracked != null)
        {
            Debug.Log($"Toggling cube for {TargetController.currentlyTracked.name}");
            TargetController.currentlyTracked.ToggleCube();
        }
        else
        {
            Debug.Log("No target currently tracked!");
        }
    }

}