using UnityEngine;

public class HistoryButtonNarration : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introClip;

    public TargetNarration darkBlueTarget;
    public TargetNarration blackTarget;
    public TargetNarration orangeTarget;
    private SubtitleGUIManager subtitleGUIManager;
    private CaptionsManager captionsManager;
    private string captionText;

    private void Awake()
    {
        captionsManager = FindObjectOfType<CaptionsManager>();
        subtitleGUIManager = FindObjectOfType<SubtitleGUIManager>();
    }

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
            captionText = captionsManager.GetText(audioSource.clip.name);
            subtitleGUIManager.SetText(captionText);
            return;
        }

        // BLACK
        else if (blackTarget != null && blackTarget.targetVisible)
        {
            Debug.Log("Black detected → playing 11_oc.wav");
            blackTarget.PlayBlackClip();
            captionText = captionsManager.GetText(audioSource.clip.name);
            subtitleGUIManager.SetText(captionText);
            return;
        }

        // ORANGE
        else if (orangeTarget != null && orangeTarget.targetVisible)
        {
            Debug.Log("Black detected → playing 11_oc.wav");
            orangeTarget.PlayOrangeSequence();
            captionText = captionsManager.GetText(audioSource.clip.name);
            subtitleGUIManager.SetText(captionText);
            return;
        }
        else{
            // NO TARGET → default intro
            Debug.Log("No target detected → playing intro");
            audioSource.clip = introClip;
            captionText = captionsManager.GetText(audioSource.clip.name);
            subtitleGUIManager.SetText(captionText);
            audioSource.Play();

        }

        
    }
}