using System;
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

    // Event fired when a clip is about to be played on this target
    public event Action<AudioClip> OnClipStarted;

    // Event fired when the current playback (single clip or sequence) finishes
    public event Action OnPlaybackEnded;

    // Track the currently running playback coroutine so we can stop it when needed
    private Coroutine playbackCoroutine;

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
        // Play a single clip using the playback coroutine (so we can signal end)
        if (playbackCoroutine != null)
            StopCoroutine(playbackCoroutine);

        playbackCoroutine = StartCoroutine(PlaySingleClip(defaultClip));
    }

    // DARK BLUE
    public void PlayDarkBlueSequence()
    {
        if (playbackCoroutine != null)
            StopCoroutine(playbackCoroutine);

        playbackCoroutine = StartCoroutine(PlayClipArray(darkBlueClips));
    }

    // ORANGE
    public void PlayOrangeSequence()
    {
        if (playbackCoroutine != null)
            StopCoroutine(playbackCoroutine);

        playbackCoroutine = StartCoroutine(PlayClipArray(orangeClips));
    }

    // BLACK
    public void PlayBlackClip()
    {
        if (playbackCoroutine != null)
            StopCoroutine(playbackCoroutine);

        playbackCoroutine = StartCoroutine(PlaySingleClip(blackClip));
    }

    // Generic coroutine for playing a sequence
    System.Collections.IEnumerator PlayClipArray(AudioClip[] clips)
    {
        foreach (var clip in clips)
        {
            Debug.Log("Playing clip: " + clip.name);

            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.volume = SettingsManager.narrationVolume;

            if (SettingsManager.narrationEnabled)
            {
                OnClipStarted?.Invoke(clip);
                audioSource.Play();
                yield return new WaitForSeconds(clip.length);
            }
            else
            {
                // If narration disabled, just skip waiting but keep timing consistent
                yield return null;
            }
        }

        // Sequence finished
        OnPlaybackEnded?.Invoke();
        playbackCoroutine = null;
    }

    // Play a single clip and signal when it ends
    private System.Collections.IEnumerator PlaySingleClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.volume = SettingsManager.narrationVolume;

        if (SettingsManager.narrationEnabled)
        {
            OnClipStarted?.Invoke(clip);
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);
        }
        else
        {
            // If narration disabled, just yield one frame and finish
            yield return null;
        }

        OnPlaybackEnded?.Invoke();
        playbackCoroutine = null;
    }
}