using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class VuforiaManager : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        // Start Vuforia camera
        VuforiaBehaviour.Instance.enabled = true;

        // Set up back button
        backButton.onClick.AddListener(ReturnToMenu);

        // iOS handles camera permissions automatically
        // The first time, iOS will show a permission dialog
    }

    // Call this when you want to go back to menu
    public void ReturnToMenu()
    {
        // Stop and cleanup Vuforia camera
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Deinit();

        // Load menu scene
        SceneManager.LoadScene("MainMenu");
    }

    void OnApplicationPause(bool pause)
    {
        // Pause camera when app goes to background
        if (pause)
        {
            CameraDevice.Instance.Stop();
        }
        else
        {
            CameraDevice.Instance.Start();
        }
    }
}
