using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyCombat enemyCombat;
    public ResourceBars resourceBars;

    public int currentPlayerScore;
    public int currentOppoScore;

    public TMP_Text phaseText;

    public TMP_Text playerScoreText;
    public TMP_Text oppoScoreText;
    public TMP_Text tryScoredText;

    public GameObject coinTossUI;
    public GameObject coinTossWonUI;
    public GameObject attackUI;
    public GameObject defenceUI;
    public GameObject kickingUI;
    public GameObject kickReturnUI;

    public TMP_Text playerMatchText;
    public TMP_Text oppoMatchText;

    private bool coinTossWon = false;

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
        currentPlayerScore += 7;
        playerScoreText.text = currentPlayerScore.ToString();
    }

    public void OppoScores()
    {
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

        if(choice == 0 && coinToss <= 50)
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
            ChangePhase("Attack Phase");
        } 
        else if (choice == "Defend")
        {
            ChangePhase("Defence Phase");
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
            coinTossWonUI.SetActive(true);
        }

        if(phase == "Coin Toss Lost")
        {
            enemyController.CoinTossWon();
        }

        if(phase == "Attack Phase")
        {
            attackUI.SetActive(true);

            defenceUI.SetActive(false);
            kickingUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Defence Phase")
        {
            defenceUI.SetActive(true);

            attackUI.SetActive(false);
            kickingUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Kicking Phase")
        {
            kickingUI.SetActive(true);

            attackUI.SetActive(false);
            defenceUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Kick Return")
        {
            kickReturnUI.SetActive(true);

            attackUI.SetActive(false);
            defenceUI.SetActive(false);
            kickingUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }
    }

    public void ChangePhaseText(string phase)
    {
        phaseText.text = phase;
    }

    public void HalfTime()
    {
        Debug.Log("Half Time");

        if(coinTossWon == true)
        {
            ChangePhase("Kicking Phase");
        }
        else
        {
            ChangePhase("Kick Return");
        }
    }

    public void FullTime()
    {
        Debug.Log("Full Time");
    }
}
