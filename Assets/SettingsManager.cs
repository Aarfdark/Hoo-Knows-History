using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle narrationToggle;
    public Slider volumeSlider;
    public CanvasGroup volumeGroup;

    void Start()
    {
        // default values at scene start
        narrationToggle.isOn = true;    
        volumeSlider.value = 1f;        

        UpdateVolumeState(narrationToggle.isOn);

        narrationToggle.onValueChanged.AddListener(UpdateVolumeState);
    }

    void UpdateVolumeState(bool enabled)
    {
        // When turning narration ON, reset slider to 100%
        if (enabled)
        {
            volumeSlider.value = 1f;  
        }

        // Lock/unlock slider
        volumeSlider.interactable = enabled;

        // Fade the volume block
        volumeGroup.alpha = enabled ? 1f : 0.3f;
        volumeGroup.interactable = enabled;
        volumeGroup.blocksRaycasts = enabled;
    }
}