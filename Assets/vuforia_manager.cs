using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;


using UnityEngine;
using UnityEngine.UI;

public class VuforiaManager : MonoBehaviour
{
    public Button backButton;
    public GameObject arContent;

    void Start()
    {
        // Hook up the button click
        backButton.onClick.AddListener(ToggleAR);
    }

    public void ToggleAR()
    {
        Debug.Log("button clicked");
        if (arContent != null)
        {
            Debug.Log("object is not null, turning off");
            arContent.SetActive(!arContent.activeSelf);
        }
        else
        {
            Debug.Log("object is  null, turning on");
            Debug.LogWarning("arContent not assigned in the Inspector!");
            arContent.SetActive(!arContent.activeSelf);
        }
    }

    // Call this when you want to go back to menu
    public void ReturnToMenu()
    {
        // Stop and cleanup Vuforia camera
        //CameraDevice.Instance.Stop();
        //CameraDevice.Instance.Deinit();

        // Load menu scene
        SceneManager.LoadScene("MainMenu");
    }

    void OnApplicationPause(bool pause)
    {
        //// Pause camera when app goes to background
        //if (pause)
        //{
        //    CameraDevice.Instance.Stop();
        //}
        //else
        //{
        //    CameraDevice.Instance.Start();
        //}
    }
}
