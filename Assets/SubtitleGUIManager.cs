using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleGUIManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    private void Awake()
    {
        ClearText();
    }

    public void ClearText()
    {
        textBox.text = string.Empty;
    }

    public void SetText(string text)
    {
        textBox.text = "<mark=#444444>" + text + "</mark>";
    }
}
