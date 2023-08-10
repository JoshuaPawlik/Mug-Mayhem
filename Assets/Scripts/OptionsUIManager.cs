using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUIManager : MonoBehaviour
{
    public Button backButton;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;

    public Toggle fullScreenToggleButton;


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

    }

    public void ToggleFullScreen()
    {
        Debug.Log("Toggling full screen");
        Screen.fullScreen = !Screen.fullScreen;
    }
}

