using UnityEngine;
using Vuforia;

public class TargetNarration : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip defaultClip;        // intro / no target
    public AudioClip[] darkBlueClips;    // 02–10
    public AudioClip blackClip;          // 11
    public AudioClip[] orangeClips;      // 12–15

    public bool targetVisible = false;

    void Start()
    {
        var observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        targetVisible = isTracked;
    }

    // Default intro
    public void PlayDefaultAudio()
    {
        audioSource.Stop();
        audioSource.clip = defaultClip;
        audioSource.volume = SettingsManager.narrationVolume;

        if (SettingsManager.narrationEnabled)
            audioSource.Play();
    }

    // DARK BLUE
    public void PlayDarkBlueSequence()
    {
        StartCoroutine(PlayClipArray(darkBlueClips));
    }

    // ORANGE
    public void PlayOrangeSequence()
    {
        StartCoroutine(PlayClipArray(orangeClips));
    }

    // BLACK
    public void PlayBlackClip()
    {
        audioSource.Stop();
        audioSource.clip = blackClip;
        audioSource.volume = SettingsManager.narrationVolume;

        if (SettingsManager.narrationEnabled)
            audioSource.Play();
    }

    // Generic coroutine for playing a sequence
    System.Collections.IEnumerator PlayClipArray(AudioClip[] clips)
    {
        foreach (var clip in clips)
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