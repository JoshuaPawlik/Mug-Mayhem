using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

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
        }

    }
}

