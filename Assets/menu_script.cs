using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startARButton;
    public GameObject arContent; // You need this defined!

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
}