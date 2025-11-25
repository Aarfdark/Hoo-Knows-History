using UnityEngine;

public class HistoryButtonNarration : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introClip;

    public TargetNarration darkBlueTarget;
    public TargetNarration blackTarget;
    public TargetNarration orangeTarget;

    public void PlayNarration()
    {
        if (!SettingsManager.narrationEnabled)
        {
            Debug.Log("Narration OFF – no audio played.");
            return;
        }

        audioSource.volume = SettingsManager.narrationVolume;
        audioSource.Stop();

        // DARK BLUE
        if (darkBlueTarget != null && darkBlueTarget.targetVisible)
        {
            Debug.Log("DarkBlue detected → playing clips 02–10");
            darkBlueTarget.PlayDarkBlueSequence();
            return;
        }

        // BLACK
        if (blackTarget != null && blackTarget.targetVisible)
        {
            Debug.Log("Black detected → playing 11_oc.wav");
            blackTarget.PlayBlackClip();
            return;
        }

        // ORANGE
        if (orangeTarget != null && orangeTarget.targetVisible)
        {
            Debug.Log("Black detected → playing 11_oc.wav");
            orangeTarget.PlayOrangeSequence();
            return;
        }

        // NO TARGET → default intro
        Debug.Log("No target detected → playing intro");
        audioSource.clip = introClip;
        audioSource.Play();
    }
}