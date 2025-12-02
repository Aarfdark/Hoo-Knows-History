using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class CaptionsManager : MonoBehaviour
{
    private Dictionary<string, string> lines = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    
    public string resourceFile = "captions";

    public string GetText(string textKey)
    {
        string tmp = "";
        if (lines.TryGetValue(textKey, out tmp))
        {
            return tmp;
        }
        return string.Empty;
    }

    private void Awake()
    {
        var textAsset = Resources.Load<TextAsset>(resourceFile);
        var voText = JsonUtility.FromJson<VoiceOverText>(textAsset.text);

        foreach (var line in voText.lines)
        {
            lines[line.key] = line.line;
        }
    }
}
