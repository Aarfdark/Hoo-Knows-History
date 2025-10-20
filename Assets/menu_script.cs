
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startARButton;

    void Start()
    {
        startARButton.onClick.AddListener(StartAR);
    }

    void StartAR()
    {
        SceneManager.LoadScene("ARScene");
    }
}