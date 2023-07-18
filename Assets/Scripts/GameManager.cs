using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        Application.Quit();
    }

}
