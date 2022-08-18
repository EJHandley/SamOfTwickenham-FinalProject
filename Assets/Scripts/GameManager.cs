using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyCombat enemyCombat;
    public ResourceBars resourceBars;
    public TryNotificationUI tryNotification;
    public Dialogue dialogueManager;
    public CommentatorDialogue commentatorDialogue;
    public TimeManager timeManager;

    public TMP_Text phaseText;

    public TMP_Text playerScoreText;
    public TMP_Text oppoScoreText;

    [Header("UI Elements")]
    public GameObject coinTossUI;
    public GameObject coinTossWonUI;
    public GameObject attackUI;
    public GameObject defenceUI;
    public GameObject kickingUI;
    public GameObject kickReturnUI;

    [Header("Tutorial UI Elements")]
    public GameObject tossWonTut;
    public GameObject tossChoiceTut;
    public GameObject attackTut;
    public GameObject defenceTut;

    [HideInInspector] public int currentPlayerScore;
    [HideInInspector] public int currentOppoScore;

    public bool isTutorialMatch;
    private bool attTutEnabled = false;
    private bool defTutEnabled = false;
    [HideInInspector] public bool coinTossWon = false;

    [Header("Move Splash UI")]
    public GameObject moveSplash;
    public Image moveImage;
    public GameObject _animation;

    [Header("Foul, Turnover and Recovery Methods")]
    public Moves foul;

    public GameObject combatFeedbackBox;
    public Transform feedbackArea;
    public List<GameObject> boxes = new List<GameObject>();

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion

    void Start()
    {
        currentPlayerScore = 0;
        currentOppoScore = 0;

        ChangePhase("Coin Toss");
    }

    void Update()
    {

    }

    #region Scoring
    public void PlayerScores()
    {
        tryNotification.StartCoroutine("PlayerScored");
        currentPlayerScore += 7;
        playerScoreText.text = currentPlayerScore.ToString();
    }

    public void OppoScores()
    {
        tryNotification.StartCoroutine("EnemyScored");
        currentOppoScore += 7;
        oppoScoreText.text = currentOppoScore.ToString();
    }
    #endregion

    //All Methods and Mechanic related to the Coin Toss Phase are held below
    #region Coin Toss Methods

    public void CoinTossChoice(string choice)
    {
        if (choice == "Heads")
        {
            CoinToss(0);
        }
        else if (choice == "Tails")
        {
            CoinToss(1);
        }
    }

    public void CoinToss(int choice)
    {
        int coinToss = Random.Range(1, 101);

        if (isTutorialMatch == true)
        {
            ChangePhase("Coin Toss Won");
            return;
        }

        if (choice == 0 && coinToss <= 50)
        {
            SetMoveFeedback("you won the toss!", "Player");
            ChangePhase("Coin Toss Won");
        }
        else if (choice == 0 && coinToss > 50)
        {
            SetMoveFeedback("you lost the toss!", "Player");
            ChangePhase("Coin Toss Lost");
        }

        if (choice == 1 && coinToss <= 50)
        {
            SetMoveFeedback("you lost the toss!", "Player");
            ChangePhase("Coin Toss Lost");
        }
        else if (choice == 1 && coinToss > 50)
        {
            SetMoveFeedback("you won the toss!", "Player");
            ChangePhase("Coin Toss Won");
        }
    }

    public void CoinTossWon(string choice)
    {
        if (choice == "Attack")
        {
            if (isTutorialMatch == true)
            {
                tossChoiceTut.SetActive(true);
            }

            ChangePhase("Kick Return");
        }
        else if (choice == "Defend")
        {
            if (isTutorialMatch == true)
            {
                tossChoiceTut.SetActive(true);
            }

            ChangePhase("Kicking Phase");
        }
    }
    #endregion

    public void ChangePhase(string phase)
    {
        if (phase == "Coin Toss")
        {
            coinTossUI.SetActive(true);
            ChangePhaseText(phase);
        }

        if (phase == "Coin Toss Won")
        {
            if (isTutorialMatch == true)
            {
                tossWonTut.SetActive(true);
            }

            coinTossWonUI.SetActive(true);
        }

        if (phase == "Coin Toss Lost")
        {
            enemyController.CoinTossWon();
        }

        if (phase == "Attack Phase")
        {
            if (isTutorialMatch == true && attTutEnabled == false)
            {
                attackTut.SetActive(true);
                attTutEnabled = true;
            }

            attackUI.SetActive(true);

            defenceUI.SetActive(false);
            kickingUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);
            coinTossWonUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if (phase == "Defence Phase")
        {
            if (isTutorialMatch == true && defTutEnabled == false)
            {
                defenceTut.SetActive(true);
                defTutEnabled = true;
            }

            defenceUI.SetActive(true);

            attackUI.SetActive(false);
            kickingUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);
            coinTossWonUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if (phase == "Kicking Phase")
        {
            kickingUI.SetActive(true);

            attackUI.SetActive(false);
            defenceUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);
            coinTossWonUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if (phase == "Kick Return")
        {
            kickReturnUI.SetActive(true);

            attackUI.SetActive(false);
            defenceUI.SetActive(false);
            kickingUI.SetActive(false);
            coinTossUI.SetActive(false);
            coinTossWonUI.SetActive(false);

            ChangePhaseText(phase);
        }
    }

    public void SetMoveFeedback(string info, string id)
    {
        while (boxes.Count >= 5)
        {
            Destroy(boxes[0]);
            boxes.Remove(boxes[0]);
        }

        GameObject feedbackBox = Instantiate(combatFeedbackBox, feedbackArea);
        boxes.Add(feedbackBox);

        TMP_Text feedbackText = feedbackBox.GetComponentInChildren<TMP_Text>();
        Image[] teamID = feedbackBox.GetComponentsInChildren<Image>();

        feedbackText.text = info;
        if(id == "Player")
        {
            teamID[1].color = new Color32(73,194,255,255);
        } else
        {
            teamID[1].color = new Color32(126,56,35,255);
        }
    }

    public void ChangePhaseText(string phase)
    {
        phaseText.text = phase;
    }

    public IEnumerator SplashUI(Moves thisMove)
    {
        _animation.SetActive(true);
        VideoController.instance.Play(thisMove.moveAnimation);
        moveSplash.SetActive(true);
        moveImage.sprite = thisMove.movePic;


        yield return new WaitForSeconds(5.9f);

        _animation.SetActive(false);
        moveSplash.SetActive(false);
    }

    public void Turnover(string user)
    {
        if (user == "Player")
        {
            ChangePhase("Defence Phase");
        }

        if (user == "Enemy")
        {
            ChangePhase("Attack Phase");
        }
    }

    public void Foul(string user)
    {
        AudioManager.instance.Play("Whistle_Foul");

        StartCoroutine(SplashUI(foul));

        commentatorDialogue.MoveDialogue(foul);
    }
}
