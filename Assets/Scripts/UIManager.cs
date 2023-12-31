using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    public Button backButton;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;

    private void Start()
    {
        // Ensure GameManager instance exists
        if(GameManager.instance != null)
        {
            if(startButton != null)
                startButton.onClick.AddListener(GameManager.instance.StartGame);
            
            if(optionsButton != null)
                optionsButton.onClick.AddListener(GameManager.instance.ShowOptions);
            
            if(quitButton != null)
                quitButton.onClick.AddListener(GameManager.instance.QuitGame);

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
    }
}
