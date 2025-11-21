using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle narrationToggle;
    public Slider volumeSlider;
    public CanvasGroup volumeGroup;

    public static bool narrationEnabled = true;
    public static float narrationVolume = 1f;

    void Awake()
    {
        if (volumeSlider != null)
            volumeSlider.value = 1f;
    }

    void Start()
    {
        narrationToggle.isOn = true;
        volumeSlider.value = 1f;

        UpdateVolumeState(narrationToggle.isOn);

        narrationToggle.onValueChanged.AddListener(UpdateVolumeState);
        volumeSlider.onValueChanged.AddListener(UpdateVolumeValue);
    }

    void UpdateVolumeState(bool enabled)
    {
        // save global setting
        narrationEnabled = enabled;

        if (enabled)
            volumeSlider.SetValueWithoutNotify(1f);

        volumeSlider.interactable = enabled;

        volumeGroup.alpha = enabled ? 1f : 0.3f;
        volumeGroup.interactable = enabled;
        volumeGroup.blocksRaycasts = enabled;

        // update global volume if it was set
        narrationVolume = volumeSlider.value;
    }

    void UpdateVolumeValue(float value)
    {
        // Always store volume globally when slider moves
        narrationVolume = value;
    }
}