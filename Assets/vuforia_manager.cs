using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VuforiaManager : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(ToggleAR);
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

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}