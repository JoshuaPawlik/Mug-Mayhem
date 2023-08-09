using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip mainGameplayMusic;

    [Header("SFX Clips")]
    public AudioClip punchSound;

    private float masterVolume = 1.0f;
    private float musicVolume = 1.0f;
    private float sfxVolume = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Assuming initial scene is Main Menu
            ChangeMusic(mainMenuMusic);
        }
        else
        {
            Destroy(this.gameObject);
            return;
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
        if (musicSource.clip != newClip)
        {
            musicSource.Stop();
            musicSource.clip = newClip;
            musicSource.volume = masterVolume * musicVolume;
            musicSource.Play();
        }
    }

    public void PlayPunchSound()
    {
        sfxSource.volume = masterVolume * sfxVolume;
        sfxSource.PlayOneShot(punchSound);
    }

    // Volume control methods
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume / 100.0f;
        GameSettings.masterVolume = masterVolume;
        UpdateVolume();
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume / 100.0f;
        GameSettings.musicVolume = musicVolume;
        UpdateVolume();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume / 100.0f;
    }

    private void UpdateVolume()
    {
        musicSource.volume = masterVolume * musicVolume;
        // We don't update the SFX source volume here because it's set when a sound effect is played.
    }
}
