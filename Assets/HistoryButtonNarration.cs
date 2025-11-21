using UnityEngine;

public class HistoryButtonNarration : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introClip;                // Audio 1
    public TargetNarration targetNarration;    // Reference to detection script

    public void PlayNarration()
    {
        // 1. Check narration enabled
        if (!SettingsManager.narrationEnabled)
        {
            Debug.Log("Narration OFF – no audio played.");
            return;
        }

        // 2. Apply global volume
        audioSource.volume = SettingsManager.narrationVolume;

        // 3. Stop any currently playing audio
        audioSource.Stop();

        // 4. If target detected → play dark blue sequence
        if (targetNarration != null && targetNarration.targetVisible)
        {
            Debug.Log("DarkBlue detected → playing clips 2–4");
            targetNarration.PlayDarkBlueSequence();
            return;
        }

        // 5. Otherwise → play intro narration
        Debug.Log("No target detected → playing intro narration");
        audioSource.clip = introClip;
        audioSource.Play();
    }
}