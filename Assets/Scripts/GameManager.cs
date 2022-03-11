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

    public TMP_Text playerScoreText;
    public TMP_Text oppoScoreText;

    public TMP_Text coinTossText;
    public GameObject coinTossUI;
    public GameObject coinTossWonUI;

    public TMP_Text attackPhaseText;
    public GameObject attackUI;

    public TMP_Text defencePhaseText;
    public GameObject defenceUI;

    public TMP_Text kickingPhaseText;
    public GameObject kickingUI;

    public TMP_Text kickReturnText;
    public GameObject kickReturnUI;

    public bool isKickingPhase;
    public bool isAttackPhase;
    public bool isDefencePhase;
    public bool isKickReturn;

    public bool choseHeads;
    public bool choseTails;

    void Start()
    {
        currentPlayerScore = 0;
        currentOppoScore = 0;

        CoinToss();
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
    public void CoinTossUI()
    {
        coinTossText.gameObject.SetActive(true);
        coinTossUI.SetActive(true);
    }

    public void ChoseHeads()
    {
        choseHeads = true;
        choseTails = false;
    }

    public void ChoseTails()
    {
        choseTails = true;
        choseHeads = false;
    }

    public void CoinToss()
    {
        int coinToss = Random.Range(1, 101);

        if(choseHeads && coinToss <= 50)
        {
            Debug.Log("You chose Heads and it's Heads!");
            CoinFlipWon();
        } 
        else if (choseHeads && coinToss > 50)
        {
            Debug.Log("You chose Heads but it's Tails!");
            CoinFlipLost();
        }

        if(choseTails && coinToss <= 50)
        {
            Debug.Log("You chose Tails but it's Heads!");
            CoinFlipLost();
        }
        else if (choseTails && coinToss > 50)
        {
            Debug.Log("You chose Tails and it's Tails!");
            CoinFlipWon();
        }
    }

    public void CoinFlipWon()
    {
        coinTossWonUI.SetActive(true);
    }

    public void CoinFlipLost()
    {
        enemyController.CoinTossWon();
    }
    #endregion

    public void AttackPhase()
    {
        isDefencePhase = true;
        isKickingPhase = false;
        isKickReturn = false;
        isAttackPhase = false;

        attackPhaseText.gameObject.SetActive(true);
        attackUI.SetActive(true);

        defencePhaseText.gameObject.SetActive(false);
        kickingPhaseText.gameObject.SetActive(false);
        kickReturnText.gameObject.SetActive(false);
        coinTossText.gameObject.SetActive(false);

        defenceUI.SetActive(false);
        kickingUI.SetActive(false);
        kickReturnUI.SetActive(false);
        coinTossUI.SetActive(false);
    }

    public void DefencePhase()
    {
        isAttackPhase = true;
        isKickingPhase = false;
        isKickReturn = false;
        isDefencePhase = false;

        defencePhaseText.gameObject.SetActive(true);
        defenceUI.SetActive(true);

        attackPhaseText.gameObject.SetActive(false);
        kickingPhaseText.gameObject.SetActive(false);
        kickReturnText.gameObject.SetActive(false);
        coinTossText.gameObject.SetActive(false);

        attackUI.SetActive(false);
        kickingUI.SetActive(false);
        kickReturnUI.SetActive(false);
        coinTossUI.SetActive(false);
    }

    public void KickingPhase()
    {
       isKickReturn = true;
       isDefencePhase = false;
       isKickingPhase = false;
       isAttackPhase = false;

       kickingPhaseText.gameObject.SetActive(true);
       kickingUI.SetActive(true);

       attackPhaseText.gameObject.SetActive(false);
       defencePhaseText.gameObject.SetActive(false);
       kickReturnText.gameObject.SetActive(false);
       coinTossText.gameObject.SetActive(false);

       attackUI.SetActive(false);
       defenceUI.SetActive(false);
       kickReturnUI.SetActive(false);
       coinTossUI.SetActive(false);
    }

    public void KickReturn()
    {
        isKickingPhase = true;
        isAttackPhase = false;
        isDefencePhase = false;
        isKickReturn = false;

        kickReturnText.gameObject.SetActive(true);
        kickReturnUI.SetActive(true);

        attackPhaseText.gameObject.SetActive(false);
        defencePhaseText.gameObject.SetActive(false);
        kickingPhaseText.gameObject.SetActive(false);
        coinTossText.gameObject.SetActive(false);

        attackUI.SetActive(false);
        defenceUI.SetActive(false);
        kickingUI.SetActive(false);
        coinTossUI.SetActive(false);
    }
}
