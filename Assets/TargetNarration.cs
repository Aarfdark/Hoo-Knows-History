using UnityEngine;
using Vuforia;

public class TargetNarration : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip defaultClip;      // Audio 1
    public AudioClip[] darkBlueClips;  // Audio 2–4

    public bool targetVisible = false;

    void Start()
    {
        var observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

        // ❌ Do NOT auto-play anything here
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        // Only update our visibility state — DO NOT PLAY AUDIO AUTOMATICALLY
        targetVisible = isTracked;
    }

    // Called by History Button
    public void PlayDefaultAudio()
    {
        audioSource.Stop();
        audioSource.clip = defaultClip;
        audioSource.volume = SettingsManager.narrationVolume;

        if (SettingsManager.narrationEnabled)
            audioSource.Play();
    }

    // Called by History Button
    public void PlayDarkBlueSequence()
    {
        StartCoroutine(PlayClipsInOrder());
    }

    System.Collections.IEnumerator PlayClipsInOrder()
    {
        foreach (var clip in darkBlueClips)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.volume = SettingsManager.narrationVolume;

            if (SettingsManager.narrationEnabled)
                audioSource.Play();

            yield return new WaitForSeconds(clip.length);
        }
    }
}