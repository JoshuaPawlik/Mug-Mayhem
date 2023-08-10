using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    // Make this class a Singleton
    public static GameManager instance = null;

    private bool isPaused = false;
    public GameObject pauseMenu;

    void Awake()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        // Keep the GameManager alive throughout the game
        DontDestroyOnLoad(gameObject);

        // Set the target frame rate to 60
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    // Function to show options menu
    public void ShowOptions()
    {
        SceneManager.LoadScene("Options");
    }

    // Function to show main menu
    public void ShowMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;  // This halts the game time
        isPaused = true;

        // Optionally, display the pause menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;  // This resumes the game time
        isPaused = false;

        // Optionally, hide the pause menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            pauseMenu = GameObject.Find("PauseMenu");

            // Ensure the pause menu is initially inactive
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Unsubscribe from the event
    }


}
