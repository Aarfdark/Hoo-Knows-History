using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class AboutUs : MonoBehaviour
{
    public Button backButton;

    public void GoToHomeScene(){
        Debug.Log("BACK BUTTON CLICKED!");
        SceneManager.LoadScene("MenuScene");
    }
}