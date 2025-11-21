using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
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