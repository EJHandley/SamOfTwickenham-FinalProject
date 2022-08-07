using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Button storyButton;
    private int storyStatus;
    public Button matchButton;

    [Header("Tutorial Elements")]
    public GameObject tutCanvas1;
    public GameObject tutCanvas2;

    private void Awake()
    {

    }

    void Start()
    {

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
            }
            else if (storyStatus == 0)
            {
                storyButton.interactable = true;
                matchButton.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("Tutorials Enabled", 0) == 1)
        {
            if(PlayerPrefs.GetInt("Story Completed", 0) == 1)
            {
                tutCanvas2.gameObject.SetActive(true);
                tutCanvas1.gameObject.SetActive(false);
            }
            else if(PlayerPrefs.GetInt("Story Completed", 0) == 1)
            {
                tutCanvas1.gameObject.SetActive(true);
                tutCanvas2.gameObject.SetActive(false);
            }

        }
    }
}
