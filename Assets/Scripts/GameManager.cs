using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

    // Make this class a Singleton
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        // Keep the GameManager alive throughout the game
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape") || Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }


    // Function to quit the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Function to start the game
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay Scene");
    }

    // Function to show options menu
    public void ShowOptions()
    {
        SceneManager.LoadScene("Options");
    }

    // Function to show main menu
    public void ShowMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
