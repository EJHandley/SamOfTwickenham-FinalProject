using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private float time = 0f;

    public TMP_Text timeText;

    public Sprite halfTimeSplash;
    public Sprite fullTimeSplash;

    public GameObject splashScreen;
    public Image splashScreenImage;
    public TMP_Text splashHomeScore;
    public TMP_Text splashAwayScore;
    public GameObject _animation;
    public GameObject fullTimeImage;
    public Image fullTimeImg;
    public Sprite winImg;
    public Sprite lossImg;

    public GameObject halfTimeContinue;
    public Button halfTimeContinueButton;
    public GameObject fullTimeContinue;
    public Button fullTimeContinueButton;

    private bool halfTimeTriggered = false;
    private bool fullTimeTriggered = false;

    public string halfTimeAnimation;

    void Start()
    {
        SetTime(time);
    }

    void Update()
    {
        
    }

    public void SetTime(float currentTime)
    {
        if (time >= 2400f && halfTimeTriggered == false)
        {
            time = 2400f;
            StartCoroutine(HalfTime());
            halfTimeTriggered = true;
            return;
        }

        if (time >= 4800f && fullTimeTriggered == false)
        {
            time = 4800f;
            StartCoroutine(FullTime());
            fullTimeTriggered = true;
            return;
        }

        time += currentTime;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    public IEnumerator HalfTime()
    {
        AudioManager.instance.Play("Whistle_HalfTime");

        yield return new WaitForSeconds(1f);

        splashScreen.SetActive(true);
        _animation.SetActive(true);
        VideoController.instance.Play(halfTimeAnimation);
        splashScreenImage.sprite = halfTimeSplash;
        splashHomeScore.text = GameManager.instance.currentPlayerScore.ToString();
        splashAwayScore.text = GameManager.instance.currentOppoScore.ToString();

        yield return new WaitForSeconds(4f);

        halfTimeContinue.SetActive(true);
        halfTimeContinueButton.interactable = true;
    }

    public void StartSecondHalf()
    {
        _animation.SetActive(false);
        splashScreenImage.sprite = null;
        splashHomeScore.text = "";
        splashAwayScore.text = "";
        splashScreen.SetActive(false);

        if (GameManager.instance.coinTossWon == true)
        {
            GameManager.instance.ChangePhase("Kicking Phase");
        }
        else
        {
            GameManager.instance.ChangePhase("Kick Return");
        }
    }

    public IEnumerator FullTime()
    {
        AudioManager.instance.Play("Whistle_FullTime");

        yield return new WaitForSeconds(1f);

        splashScreen.SetActive(true);
        fullTimeImage.SetActive(true);
        splashScreenImage.sprite = fullTimeSplash;
        splashHomeScore.text = GameManager.instance.currentPlayerScore.ToString();
        splashAwayScore.text = GameManager.instance.currentOppoScore.ToString();
        if(int.Parse(GameManager.instance.playerScoreText.text) >= int.Parse(GameManager.instance.oppoScoreText.text))
        {
            fullTimeImg.sprite = winImg;
        }
        else
        {
            fullTimeImg.sprite = lossImg;
        }

        yield return new WaitForSeconds(4f);

        fullTimeContinue.SetActive(true);
        fullTimeContinueButton.interactable = true;
    }

    public void EndGame()
    {
        int playerScore = int.Parse(GameManager.instance.playerScoreText.text);
        int oppoScore = int.Parse(GameManager.instance.oppoScoreText.text);

        if (playerScore > oppoScore)
        {
            StartCoroutine(GameWon());
        }

        if (playerScore < oppoScore)
        {
            StartCoroutine(GameLost());
        }

        if (playerScore == oppoScore)
        {
            StartCoroutine(GameDraw());
        }
    }

    public IEnumerator GameWon()
    {
        yield return new WaitForEndOfFrame();

        ConferenceDialogue.gameWon = true;
        LevelManager.instance.LoadScene("PostMatchPressConference");
    }

    public IEnumerator GameLost()
    {
        yield return new WaitForEndOfFrame();

        ConferenceDialogue.gameWon = false;
        LevelManager.instance.LoadScene("PostMatchPressConference");
    }

    public IEnumerator GameDraw()
    {
        yield return new WaitForEndOfFrame();

        ConferenceDialogue.gameWon = true;
        LevelManager.instance.LoadScene("PostMatchPressConference");
    }
}
