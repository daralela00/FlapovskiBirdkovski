using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuLogic : MonoBehaviour
{
    
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    public Slider BGMusicSlider;
    public AudioSource backgroundMusic;
    
    

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        loadVolume();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setVolume(float value)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("BGMusicValue", value);
        PlayerPrefs.Save();
    }

    public void loadVolume()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("BGMusicValue", 1) * 20));
        BGMusicSlider.value = PlayerPrefs.GetFloat("BGMusicValue", 1);
    }
}
