using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {

    }

    #region Kicks
    public void UseKickOne()
    {
        int recoveryCheck = Random.Range(1, 101);

        //This will come from the move
        int recoveryChance = 10;

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(25, 41);
        gameManager.resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        if (recoveryCheck < recoveryChance)
        {
            Debug.Log("OPPONENT RECOVERED THE BALL!");
            gameManager.DefencePhase();
            return;
        }
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.AttackPhase();
        }
    }

    public void UseKickTwo()
    {
        int recoveryCheck = Random.Range(1, 101);

        //This will come from the move
        int recoveryChance = 40;

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(10, 16);
        gameManager.resourceBars.ChangeMeters(meters);

        if (recoveryCheck < recoveryChance)
        {
            gameManager.DefencePhase();
            return;
        }
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.AttackPhase();
        }
    }

    public void KickReturn()
    {

    }
    #endregion

    #region Attacks
    public void UseAttackOne()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 10;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            gameManager.AttackPhase();
            return;
        }

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(5, 11);
        gameManager.resourceBars.ChangeMeters(meters);

        int fatigue = gameManager.resourceBars.startingFatigue -= 5;
        gameManager.resourceBars.ChangeFatigue(fatigue);
    }

    public void UseAttackTwo()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 40;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            gameManager.AttackPhase();
            return;
        }

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(15, 21);
        gameManager.resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = gameManager.resourceBars.startingFatigue -= 10;
        gameManager.resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
    }

    public void UseAttackThree()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 75;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");

            int turnoverMeters = gameManager.resourceBars.startingMeters -= Random.Range(40, 61);
            gameManager.resourceBars.ChangeMeters(turnoverMeters);

            int turnoverFatigue = gameManager.resourceBars.startingFatigue -= 30;
            gameManager.resourceBars.ChangeFatigue(turnoverFatigue);

            gameManager.AttackPhase();
            return;
        }

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(40, 61);
        gameManager.resourceBars.ChangeMeters(meters);

        int fatigue = gameManager.resourceBars.startingFatigue -= 30;
        gameManager.resourceBars.ChangeFatigue(fatigue);
    }

    public void UseAttackFour()
    {

    }

    public void UseAttackFive()
    {

    }

    public void UseAttackSix()
    {

    }
    #endregion

    #region Defence
    public void UseDefenceOne()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 0;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.DefencePhase();
            return;
        }

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(2, 6);
        gameManager.resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = gameManager.resourceBars.startingFatigue -= 5;
        gameManager.resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
    }

    public void UseDefenceTwo()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 15;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.DefencePhase();
            return;
        }

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(3, 8);
        gameManager.resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = gameManager.resourceBars.startingFatigue -= 10;
        gameManager.resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

    }

    public void UseDefenceThree()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 20;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.DefencePhase();
            return;
        }

        int meters = gameManager.resourceBars.startingMeters += Random.Range(10, 15);
        gameManager.resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = gameManager.resourceBars.startingFatigue += 10;
        gameManager.resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
    }

    public void UseDefenceFour()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceFive()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceSix()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }
    #endregion

}
