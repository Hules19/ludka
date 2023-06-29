
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    private float savedVolume;
    private float savedBrightness;

    private const string VolumeKey = "Volume";
    private const string BrightnessKey = "Brightness";

    private void Start()
    {
        LoadOptions();
    }

    public void SaveOptions()
    {
        savedVolume = volumeSlider.value;
        savedBrightness = brightnessSlider.value;

        PlayerPrefs.SetFloat(VolumeKey, savedVolume);
        PlayerPrefs.SetFloat(BrightnessKey, savedBrightness);
        PlayerPrefs.Save();
    }

    public void LoadOptions()
    {
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            savedVolume = PlayerPrefs.GetFloat(VolumeKey);
            volumeSlider.value = savedVolume;
        }
        else
        {
            savedVolume = volumeSlider.value;
            PlayerPrefs.SetFloat(VolumeKey, savedVolume);
        }

        if (PlayerPrefs.HasKey(BrightnessKey))
        {
            savedBrightness = PlayerPrefs.GetFloat(BrightnessKey);
            brightnessSlider.value = savedBrightness;
        }
        else
        {
            savedBrightness = brightnessSlider.value;
            PlayerPrefs.SetFloat(BrightnessKey, savedBrightness);
        }
    }

    public void ApplyVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void ApplyBrightness()
    {
        // Adjust the brightness of your game's display using the brightnessSlider.value
        // You can control the brightness through post-processing effects, shaders, or other appropriate methods
    }
}
