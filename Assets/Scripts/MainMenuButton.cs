using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject SoundOnOffButton;
    [SerializeField] private GameObject soundOnOffText;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private TextMeshProUGUI soundOnOffTMP;

    [SerializeField] private GameObject optionsMenu;

    
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        optionsButton.SetActive(false);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        optionsButton.SetActive(false);

        
    }
    public void ReturnMainMenu()
    {
        optionsMenu.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        optionsButton.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnMainMenuToLoseScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void Sound()
    {
        if (AudioListener.pause)
        {
            soundOnOffTMP.text = "Sound Off";
            AudioListener.pause = false;
        }
        else
        {
            soundOnOffTMP.text = "Sound On";
            AudioListener.pause = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
