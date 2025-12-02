using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleGUIManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    public void ClearText()
    {
        textBox.text = string.Empty;
    }

    public void SetText(string text)
    {
        textBox.text = text;
    }
}
