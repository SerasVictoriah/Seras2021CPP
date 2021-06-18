using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;
    public Button backButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;
    public Button resumeButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    [Header("Text")]
    public Text livesText;
    public Text volSliderText;

    [Header("Slider")]
    public Slider volSlider;

    [Header("Audio")]
    public AudioClip pauseSound;
    public AudioMixerGroup soundFXMixer;
    AudioSource pauseSoundAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
        }

        if (settingsButton)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }

        if (backButton)
        {
            backButton.onClick.AddListener(() => ShowMainMenu());
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }

        if (returnToMenuButton)
        {
            returnToMenuButton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());
        }

        if (returnToGameButton)
        {
            returnToGameButton.onClick.AddListener(() => ReturnToGame());
        }

        if (livesText)
        {
            SetLivesText();
        }

    }

    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SetLivesText()
    {
        if (GameManager.instance)
        {
            livesText.text = GameManager.instance.lives.ToString();
        }
        else
        {
            SetLivesText();
        }
    }

    void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);

                if (!pauseSoundAudio)
                {
                    pauseSoundAudio = gameObject.AddComponent<AudioSource>();
                    pauseSoundAudio.clip = pauseSound;
                    pauseSoundAudio.outputAudioMixerGroup = soundFXMixer;
                    pauseSoundAudio.loop = false;
                }

                if (pauseMenu.activeSelf)
                {
                    Time.timeScale = 0;
                    
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                volSliderText.text = volSlider.value.ToString();
            }
        }
    }
}