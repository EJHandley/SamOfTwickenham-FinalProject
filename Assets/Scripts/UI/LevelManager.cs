using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    [Header("Tutorial Variables")]
    public bool tutorialsEnabled;

    [Header("UI Elements")]
    public Button coachButton;
    public Button matchButton;
    private int storyStatus;

    [Header("Stats Screen Variables")]
    public BuffManager buffManager;
    public PlayerStats playerStats;
    public GameObject statScreen;
    public TMP_Text egoValue;
    public TMP_Text tmValue;

    [Header("Date And Time Variables")]
    public TMP_Text time;
    public TMP_Text date;

    [Header("Currency Variables")]
    public Currency currency;
    public TMP_Text money;

    [Header("Options Variables")]
    private GameObject pauseMenu;
    private GameObject optionsMenu;
    private AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    [Header("Level Audio")]
    public string sceneAudio;

    void Start()
    {
        pauseMenu = transform.Find("PauseMenu").gameObject;
        optionsMenu = transform.Find("Options").gameObject;

        audioMixer = AudioManager.instance.master;
        resolutions = Screen.resolutions;

        SetStats();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
            {
                Options();
                return;
            }

            PauseMenu();
        }


        storyStatus = PlayerPrefs.GetInt("Story Completed", 0);

        if(matchButton != null)
        {
            if (storyStatus == 1)
            {
                matchButton.interactable = true;
            }
            else if (storyStatus == 0)
            {
                matchButton.interactable = false;
            }
        }

        if(matchButton != null)
        {
            if(MoveSelector.attackMoves.Count < 6 || MoveSelector.defenceMoves.Count < 6)
            {
                matchButton.interactable = false;
            }
        }

        if(coachButton != null)
        {
            if (storyStatus == 1)
            {
                coachButton.interactable = false;
            }
            else if (storyStatus == 0)
            {
                coachButton.interactable = true;
            }
        }

        if(sceneAudio != "")
        {
            Debug.Log("Playing: " + AudioManager.currentlyPlaying);

            if (AudioManager.currentlyPlaying != sceneAudio)
            {
                LoadAudio();
            }
        }



        UpdateDateAndTime();
        UpdateCurrency();
    }

    public void LoadScene(string scene)
    {
        AudioManager.instance.Play("ButtonClick");

        SceneManager.LoadScene(scene);
    }

    public void LoadAudio()
    {
        Debug.Log("Now Playing: " + AudioManager.currentlyPlaying);

        AudioManager.instance.StopPlaying(AudioManager.currentlyPlaying);
        AudioManager.instance.Play(sceneAudio);
    }

    public void TutorialsEnabled(bool isTrue)
    {
        tutorialsEnabled = isTrue;
        SetTutorialOn();
    }

    public void SetTutorialOn()
    {
        if(!tutorialsEnabled)
        {
            PlayerPrefs.SetInt("Tutorials Enabled", 0);
            Debug.Log(PlayerPrefs.GetInt("Tutorials Enabled", 0).ToString());
        }
        else if(tutorialsEnabled)
        {
            PlayerPrefs.SetInt("Tutorials Enabled", 1);
            Debug.Log(PlayerPrefs.GetInt("Tutorials Enabled", 0).ToString());
        }
    }

    #region InfoBar
    public void DiplayStats()
    {
        statScreen.SetActive(!statScreen.activeSelf);
    }

    public void SetStats()
    {
        egoValue.text = playerStats.egoValue.ToString();
        tmValue.text = playerStats.teamValue.ToString();
    }

    public void ResetStats()
    {
        PlayerPrefs.SetInt("Story Completed", 0);
        playerStats.egoValue = 50;
        playerStats.teamValue = 50;
        buffManager.StatCheck();
        SetStats();
    }

    private void UpdateDateAndTime()
    {
        time.text = System.DateTime.Now.ToString("HH:mm");
        date.text = System.DateTime.Now.ToString("dd/MM/yy");
    }

    private void UpdateCurrency()
    {
        money.text = "$" + currency.pounds.ToString("00") + "." + currency.pence.ToString("00");
    }
    #endregion

    #region PauseMenu
    public void PauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    #endregion

    #region Options
    public void Options()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);

        if (optionsMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
