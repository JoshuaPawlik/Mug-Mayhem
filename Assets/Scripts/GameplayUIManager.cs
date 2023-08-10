using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{

    public Button resumeButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        // Ensure GameManager instance exists
        if(GameManager.instance != null)
        {
            if(resumeButton != null)
                resumeButton.onClick.AddListener(GameManager.instance.ResumeGame);
            
            if(quitButton != null)
                quitButton.onClick.AddListener(GameManager.instance.ShowMainMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
