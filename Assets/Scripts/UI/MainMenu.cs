using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Player Stats Ref")]
    public Stat playerStats;
    public TMP_Text egoValue;
    public TMP_Text tmValue;

    [Header("UI Elements")]
    public Button storyButton;
    private int storyStatus;
    public Button matchButton;

    [Header("Tutorial Elements")]
    public GameObject tutCanvas1;
    public GameObject tutCanvas2;

    public bool isMainMenu;

    private void Awake()
    {

    }

    void Start()
    {
        if(isMainMenu)
        {
            AudioManager.instance.Play("MainTheme1");
        }

        if (playerStats != null)
        {
            DisplayStats();
        }

    }

    void Update()
    {
        if(storyButton != null && matchButton != null)
        {
            storyStatus = PlayerPrefs.GetInt("Story Completed", 0);

            if (storyStatus == 1)
            {
                storyButton.interactable = false;
                matchButton.interactable = true;
                tutCanvas2.gameObject.SetActive(true);
                tutCanvas1.gameObject.SetActive(false);
            }
            else if (storyStatus == 0)
            {
                storyButton.interactable = true;
                matchButton.interactable = false;
                tutCanvas1.gameObject.SetActive(true);
                tutCanvas2.gameObject.SetActive(false);
            }
        }
    }

    public void DisplayStats()
    {
        egoValue.text = playerStats.egoValue.ToString();
        tmValue.text = playerStats.teamValue.ToString();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Story Completed", 0);
        playerStats.egoValue = 0;
        playerStats.teamValue = 0;
        DisplayStats();
    }
}
