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

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null)
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
        if(choice == "Heads")
        {
            CoinToss(0);
        }
        else if(choice == "Tails")
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
            Debug.Log("You chose Heads and it's Heads!");
            ChangePhase("Coin Toss Won");
        } 
        else if (choice == 0 && coinToss > 50)
        {
            Debug.Log("You chose Heads but it's Tails!");
            ChangePhase("Coin Toss Lost");
        }

        if(choice == 1 && coinToss <= 50)
        {
            Debug.Log("You chose Tails but it's Heads!");
            ChangePhase("Coin Toss Lost");
        }
        else if (choice == 1 && coinToss > 50)
        {
            Debug.Log("You chose Tails and it's Tails!");
            ChangePhase("Coin Toss Won");
        }
    }

    public void CoinTossWon(string choice)
    {
        if(choice == "Attack")
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
        if(phase == "Coin Toss")
        {
            coinTossUI.SetActive(true);
            ChangePhaseText(phase);
        }

        if(phase == "Coin Toss Won")
        {
            if(isTutorialMatch == true)
            {
                tossWonTut.SetActive(true);
            }

            coinTossWonUI.SetActive(true);
        }

        if(phase == "Coin Toss Lost")
        {
            enemyController.CoinTossWon();
        }

        if(phase == "Attack Phase")
        {
            if(isTutorialMatch == true && attTutEnabled == false)
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

        if(phase == "Defence Phase")
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

        if(phase == "Kicking Phase")
        {
            kickingUI.SetActive(true);

            attackUI.SetActive(false);
            defenceUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);
            coinTossWonUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Kick Return")
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

    public void ChangePhaseText(string phase)
    {
        phaseText.text = phase;
    }

    public void TestSplash(Moves move)
    {
        StartCoroutine(SplashUI(move));
    }

    public IEnumerator SplashUI(Moves thisMove)
    {
        moveSplash.SetActive(true);
        moveImage.sprite = thisMove.movePic;
        Debug.Log("TEST");

        yield return new WaitForSeconds(4f);

        moveSplash.SetActive(false);
    }
}
