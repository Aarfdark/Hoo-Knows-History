using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle narrationToggle;
    public Slider volumeSlider;
    public CanvasGroup volumeGroup;

    void Awake()
    {
        // Force slider to 100% BEFORE Unity loads UI state
        if (volumeSlider != null)
            volumeSlider.value = 1f;
    }

    void Start()
    {
        // Default toggle state
        narrationToggle.isOn = true;

        // Ensure slider is correct at scene start
        volumeSlider.value = 1f;

        // Apply initial UI lock/unlock + fades
        UpdateVolumeState(narrationToggle.isOn);

        // React to user toggling narration ON/OFF
        narrationToggle.onValueChanged.AddListener(UpdateVolumeState);
    }

    void UpdateVolumeState(bool enabled)
    {
        // If narration is turned ON, place slider back at 100%
        if (enabled)
            volumeSlider.value = 1f;

        // Enable or disable slider interactivity
        volumeSlider.interactable = enabled;

        // Fade volume block + disable raycasts when OFF
        volumeGroup.alpha = enabled ? 1f : 0.3f;
        volumeGroup.interactable = enabled;
        volumeGroup.blocksRaycasts = enabled;
    }
}