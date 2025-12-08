using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class HistoryButtonAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayHistoryAudio()
    {
        // If narration is OFF → do nothing
        if (!SettingsManager.narrationEnabled)
        {
            Debug.Log("Narration OFF – no audio played.");
            return;
        }

        // Narration ON → set volume + play
        audioSource.volume = SettingsManager.narrationVolume;
        audioSource.Play();
    }
}