using UnityEngine;
using UnityEngine.UI;

public class HistoryButtonNarration : MonoBehaviour
{
    public AudioSource audioSource;
    public ImageTargetDetector detector;

    public AudioClip introClip;      // 01
    public AudioClip[] darkBlueClips; // 02-04

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayNarration);
    }

    void PlayNarration()
    {
        audioSource.Stop();

        if (detector.isDetected)
        {
            StartCoroutine(PlaySequence());
        }
        else
        {
            audioSource.clip = introClip;
            audioSource.Play();
        }
    }

    System.Collections.IEnumerator PlaySequence()
    {
        foreach (var clip in darkBlueClips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);
        }
    }
}