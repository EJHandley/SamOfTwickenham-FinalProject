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
    public TMP_Text tryScoredText;

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

    public TMP_Text tutorialText;
    public TMP_Text playerMatchText;
    public TMP_Text oppoMatchText;

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
        tryScoredText.text = "You scored a Try!!!!!";
    }

    public void OppoScores()
    {
        currentOppoScore += 7;
        tryScoredText.text = "Your opponent scored a try!";
    }
    #endregion

    //All Methods and Mechanic related to the Coin Toss Phase are held below
    #region Coin Toss Methods
    public void CoinTossUI()
    {
        coinTossText.gameObject.SetActive(true);
        coinTossUI.SetActive(true);

        tutorialText.text = "As is customary in Rugby games, you start with a coin toss. Win the toss and you'll be able to choose whether to start the game attacking or defending.";
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
        CoinTossUI();

        int coinToss = Random.Range(1, 101);

        if(choseHeads && coinToss <= 50)
        {
            Debug.Log("You chose Heads and it's Heads!");
            tutorialText.text = "You chose Heads and you won the toss! You can now choose whether to Attack the opposition, or Defend against them...";
            CoinFlipWon();
        } 
        else if (choseHeads && coinToss > 50)
        {
            Debug.Log("You chose Heads but it's Tails!");
            CoinFlipLost("You chose Heads but the coin came up Tails, the opponent can now choose and they decide to ");
        }

        if(choseTails && coinToss <= 50)
        {
            Debug.Log("You chose Tails but it's Heads!");
            CoinFlipLost("You chose Tails but the coin came up Heads, the opponent can now choose and they decide to ");
        }
        else if (choseTails && coinToss > 50)
        {
            Debug.Log("You chose Tails and it's Tails!");
            tutorialText.text = "You chose Tails and you won the toss! You can now choose whether to Attack the opposition, or Defend against them...";
            CoinFlipWon();
        }
    }

    public void CoinFlipWon()
    {
        coinTossWonUI.SetActive(true);
    }

    public void CoinFlipLost(string text)
    {
        enemyController.CoinTossWon(text);
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

        tutorialText.text = "You are attacking. Your team now have to work their way up the field, either through grit and teamwork, or fancy moves in order to score a try." +
            " Select a move below and try to advance the ball.";
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

        tutorialText.text = "You are defending. Your team now have to prevent the opponent for advancing down the field, either by individual brilliance or team tactics. " +
            "Select a move below and try to stop your opponent.";
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
        coinTossText.gameObject.SetActive(false);

        attackUI.SetActive(false);
        defenceUI.SetActive(false);
        kickingUI.SetActive(false);
        coinTossUI.SetActive(false);
    }
}
