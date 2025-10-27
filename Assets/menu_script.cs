
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startARButton;
    public Button settingsButton;

    void Start()
    {
        startARButton.onClick.AddListener(StartAR);
    }

    void StartAR()
    {
        Debug.Log("Start AR button clicked");
        SceneManager.LoadScene("ARScene");
    }
}