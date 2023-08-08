using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    AudioSource audioSource;

    public static Music instance;

    public AudioClip mainMenuMusic; // Drag main menu and options music here in editor
    public AudioClip mainGameplayMusic; // Drag main gameplay music here in editor

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            audioSource = GetComponent<AudioSource>();

            // Check which scene is loaded initially and play the appropriate music
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Gameplay")
            {
                ChangeMusic(mainGameplayMusic);
            }
            else
            {
                ChangeMusic(mainMenuMusic);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            ChangeMusic(mainGameplayMusic);
        }
        else if (scene.name == "Main Menu" || scene.name == "Options")
        {
            ChangeMusic(mainMenuMusic);
        }
    }

    void ChangeMusic(AudioClip newClip)
    {
        if (audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
