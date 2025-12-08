using UnityEngine;
using Vuforia;

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
        captionsManager = FindFirstObjectByType<CaptionsManager>();
        subtitleGUIManager = FindFirstObjectByType<SubtitleGUIManager>();
        // captionsManager = FindObjectOfType<CaptionsManager>();
        // subtitleGUIManager = FindObjectOfType<SubtitleGUIManager>();
        // subscribe to target clip events so we can update captions when targets play
        if (darkBlueTarget != null)
        {
            darkBlueTarget.OnClipStarted += HandleTargetClipStarted;
            darkBlueTarget.OnPlaybackEnded += HandlePlaybackEnded;
        }
        if (blackTarget != null)
        {
            blackTarget.OnClipStarted += HandleTargetClipStarted;
            blackTarget.OnPlaybackEnded += HandlePlaybackEnded;
        }
        if (orangeTarget != null)
        {
            orangeTarget.OnClipStarted += HandleTargetClipStarted;
            orangeTarget.OnPlaybackEnded += HandlePlaybackEnded;
        }
    }

    private void OnDestroy()
    {
        if (darkBlueTarget != null)
        {
            darkBlueTarget.OnClipStarted -= HandleTargetClipStarted;
            darkBlueTarget.OnPlaybackEnded -= HandlePlaybackEnded;
        }
        if (blackTarget != null)
        {
            blackTarget.OnClipStarted -= HandleTargetClipStarted;
            blackTarget.OnPlaybackEnded -= HandlePlaybackEnded;
        }
        if (orangeTarget != null)
        {
            orangeTarget.OnClipStarted -= HandleTargetClipStarted;
            orangeTarget.OnPlaybackEnded -= HandlePlaybackEnded;
        }
    }

    private void HandleTargetClipStarted(AudioClip clip)
    {
        if (clip == null || captionsManager == null || subtitleGUIManager == null)
            return;

        Debug.Log("Target started clip → fetching caption for: " + clip.name);
        captionText = captionsManager.GetText(clip.name);
        if(SettingsManager.captionsEnabled)
            subtitleGUIManager.SetText(captionText);
    }

    private void HandlePlaybackEnded()
    {
        if (subtitleGUIManager == null)
            return;

        Debug.Log("Playback ended → clearing captions");
        subtitleGUIManager.SetText("");
    }

    private System.Collections.IEnumerator ClearCaptionsAfterIntro(AudioClip clip)
    {
        if (clip == null)
            yield break;

        yield return new WaitForSeconds(clip.length);

        // only clear if the intro clip is still the one we played (not replaced)
        if (audioSource.clip == clip)
            subtitleGUIManager.SetText("");
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
            return;
        }

        // BLACK
        else if (blackTarget != null && blackTarget.targetVisible)
        {
            Debug.Log("Black detected → playing 11_oc.wav");
            blackTarget.PlayBlackClip();
            return;
        }

        // ORANGE
        else if (orangeTarget != null && orangeTarget.targetVisible)
        {
            Debug.Log("Black detected → playing 11_oc.wav");
            orangeTarget.PlayOrangeSequence();
            return;
        }
        else{
            // NO TARGET → default intro
            Debug.Log("No target detected → playing intro");
            audioSource.clip = introClip;

            // captions
            Debug.Log("Fetching caption for clip: " + audioSource.clip.name);
            captionText = captionsManager.GetText(audioSource.clip.name);

            if(SettingsManager.captionsEnabled)
                subtitleGUIManager.SetText(captionText);

            audioSource.Play();

            // clear caption after this intro clip finishes
            StartCoroutine(ClearCaptionsAfterIntro(audioSource.clip));

        }

        
    }
}