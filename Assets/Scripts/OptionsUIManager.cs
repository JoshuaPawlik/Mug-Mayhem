using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsUIManager : MonoBehaviour
{
    public Button backButton;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;

    public Toggle fullScreenToggleButton;
    public TMP_Dropdown resolutionDropdown;

    private int currentResolutionIndex = 0;
    private Resolution[] availableResolutions;


    private void Start()
    {
        // Ensure GameManager instance exists
        if(GameManager.instance != null)
        {
            if(backButton != null)
                backButton.onClick.AddListener(GameManager.instance.ShowMainMenu);
        }

        // Assign listeners to the sliders
        if (AudioManager.instance != null)
        {
            if (masterVolumeSlider != null)
                masterVolumeSlider.onValueChanged.AddListener(AudioManager.instance.SetMasterVolume);

            if (musicVolumeSlider != null)
                musicVolumeSlider.onValueChanged.AddListener(AudioManager.instance.SetMusicVolume);
        }

        // Set the slider values based on the current settings
        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.value = GameSettings.masterVolume * 100.0f;  // Convert from [0,1] to [0,100]
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = GameSettings.musicVolume * 100.0f; // Convert from [0,1] to [0,100]
        }

        if (resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();

            availableResolutions = Screen.resolutions;  // Fetch the available resolutions

            List<string> options = new List<string>();
            HashSet<string> addedResolutions = new HashSet<string>();  // This set will help in filtering duplicates

            for (int i = 0; i < availableResolutions.Length; i++)
            {
                string option = availableResolutions[i].width + "x" + availableResolutions[i].height;

                // Only add the resolution if it hasn't been added before
                if (!addedResolutions.Contains(option))
                {
                    options.Add(option);
                    addedResolutions.Add(option);  // Mark this resolution as added

                    // Check if it's the current resolution
                    if (availableResolutions[i].width == Screen.currentResolution.width &&
                        availableResolutions[i].height == Screen.currentResolution.height)
                    {
                        currentResolutionIndex = options.Count - 1;  // Assign the index based on the options list
                    }
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            resolutionDropdown.onValueChanged.AddListener(SetResolution);
        }



    }
    void SetResolution(int index)
    {
        Resolution newRes = availableResolutions[index];
        Screen.SetResolution(newRes.width, newRes.height, Screen.fullScreen);
        currentResolutionIndex = index;
    }



    public void ToggleFullScreen()
    {
        Debug.Log("Toggling full screen");
        Screen.fullScreen = !Screen.fullScreen;
    }
}

