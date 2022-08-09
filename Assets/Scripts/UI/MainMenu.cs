using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private int tutorialStatus;
    private int storyStatus;

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
        tutorialStatus = PlayerPrefs.GetInt("Tutorials Enabled", 0);

        if (tutorialStatus == 1)
        {
            if(storyStatus == 1)
            {
                tutCanvas2.gameObject.SetActive(true);
                tutCanvas1.gameObject.SetActive(false);
            }
            else if(storyStatus == 0)
            {
                tutCanvas1.gameObject.SetActive(true);
                tutCanvas2.gameObject.SetActive(false);
            }

        }
    }
}
