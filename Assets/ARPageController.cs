using UnityEngine;
using UnityEngine.SceneManagement;

public class ARPageController : MonoBehaviour
{
    public GameObject ARUI;
    public GameObject SettingsUI;

    public GameObject ARCamera;     // 👈 add this
    public GameObject VuforiaManager;

    void Start()
    {
        // If launched from the Menu and we want to start directly in Settings mode
        if (PlayerPrefs.GetInt("openSettings", 0) == 1)
        {
            OpenSettings();                
            PlayerPrefs.SetInt("openSettings", 0);  // Reset it
        }
    }

    public void OpenSettings()
    {
        ARUI.SetActive(false);
        SettingsUI.SetActive(true);

        ARCamera.SetActive(false);
        VuforiaManager.SetActive(false);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
        ARUI.SetActive(true);

        ARCamera.SetActive(true);
        VuforiaManager.SetActive(true);
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadAR()
    {
        SceneManager.LoadScene("ARScene");
    }
}