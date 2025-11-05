using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VuforiaManager : MonoBehaviour
{
    public Button toggleButton;

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleAR);
    }
    
    public void GoToHome(){
        SceneManager.LoadScene("MenuScene");
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