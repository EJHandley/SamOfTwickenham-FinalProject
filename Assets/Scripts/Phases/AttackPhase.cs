using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPhase : MonoBehaviour
{
    public GameManager gameManager;
    public ResourceBars resourceBars;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UseMoveOne()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 40;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            gameManager.DefencePhase();
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(15, 21);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        gameManager.enemyController.EnemyAttack();
    }

    public void UseMoveTwo()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 75;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            gameManager.DefencePhase();
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(40, 61);
        resourceBars.ChangeMeters(meters);

        int fatigue = resourceBars.startingFatigue += 30;
        resourceBars.ChangeFatigue(fatigue);

        gameManager.enemyController.EnemyAttack();
    }

    public void UseMoveThree()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 10;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            gameManager.DefencePhase();
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(5, 11);
        resourceBars.ChangeMeters(meters);

        int fatigue = resourceBars.startingFatigue += 5;
        resourceBars.ChangeFatigue(fatigue);

        gameManager.enemyController.EnemyAttack();
    }
}
