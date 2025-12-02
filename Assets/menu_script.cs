using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class MenuManager : MonoBehaviour
{
    public Button startARButton;
    public GameObject arContent; // You need this defined!
    public Button aboutUsButton;
    public Button tutorialButton;
    public Button backButton;

    public Button settingsButton;

    void Start()
    {
        // Make sure to use onClick.AddListener, not addEventListener
        startARButton.onClick.AddListener(ToggleAR);
    }

    public void ToggleAR()
    {
        if (arContent != null)
        {
            // Use 'activeSelf', not 'activateSelf'
            arContent.SetActive(!arContent.activeSelf);
        }
        else
        {
            Debug.LogWarning("arContent not assigned in the inspector!");
        }
    }

    public void GotToARScene(){
        SceneManager.LoadScene("ARScene");
    }

    public void GoToAboutScene(){
        SceneManager.LoadScene("AboutUsScene");
    }

    public void GoToTutorialScene(){
        SceneManager.LoadScene("AboutUsScene");
    }

    public void GoToHomeScene(){
        SceneManager.LoadScene("MenuScene");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Mouse click detected");
    }

    void StartAR()
    {
        Debug.Log("hello!");
        SceneManager.LoadScene("ARScene");
    }

    public void LoadARSettings()
    {
        // Store a flag so ARScene knows to open settings immediately
        PlayerPrefs.SetInt("openSettings", 1);
        SceneManager.LoadScene("ARScene");
    }
}