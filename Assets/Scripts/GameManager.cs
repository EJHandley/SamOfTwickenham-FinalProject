using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public EnemyController enemyController;
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

    public bool isKickingPhase;
    public bool isAttackPhase;
    public bool isDefencePhase;
    public bool isKickReturn;

    public bool choseHeads;
    public bool choseTails;

    private bool coinTossWon = false;

    void Start()
    {
        currentPlayerScore = 0;
        currentOppoScore = 0;

        ChangePhase("Coin Toss");
    }

    void Update()
    {
        playerScoreText.text = currentPlayerScore.ToString();
        oppoScoreText.text = currentOppoScore.ToString();
    }

    #region Scoring
    public void PlayerScores()
    {
        currentPlayerScore += 7;
    }

    public void OppoScores()
    {
        currentOppoScore += 7;
    }
    #endregion

    //All Methods and Mechanic related to the Coin Toss Phase are held below
    #region Coin Toss Methods

    public void ChoseHeads()
    {
        CoinToss(0);
    }

    public void ChoseTails()
    {
        CoinToss(1);
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
            coinTossWon = true;
            coinTossWonUI.SetActive(true);
            ChangePhaseText("Coin Toss");
        }

        if(phase == "Coin Toss Lost")
        {
            enemyController.CoinTossWon();
            ChangePhaseText("Coin Toss");
        }

        if(phase == "Attack Phase")
        {
            isDefencePhase = true;
            isKickingPhase = false;
            isKickReturn = false;
            isAttackPhase = false;

            attackUI.SetActive(true);
            defenceUI.SetActive(false);
            kickingUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Defence Phase")
        {
            isAttackPhase = true;
            isKickingPhase = false;
            isKickReturn = false;
            isDefencePhase = false;

            defenceUI.SetActive(true);
            attackUI.SetActive(false);
            kickingUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Kicking Phase")
        {
            isKickReturn = true;
            isDefencePhase = false;
            isKickingPhase = false;
            isAttackPhase = false;

            kickingUI.SetActive(true);
            attackUI.SetActive(false);
            defenceUI.SetActive(false);
            kickReturnUI.SetActive(false);
            coinTossUI.SetActive(false);

            ChangePhaseText(phase);
        }

        if(phase == "Kick Return")
        {
            isKickingPhase = true;
            isAttackPhase = false;
            isDefencePhase = false;
            isKickReturn = false;

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
