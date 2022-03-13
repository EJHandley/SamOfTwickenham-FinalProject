using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencePhase : MonoBehaviour
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
        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 0;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.DefencePhase();
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(3, 7);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 5;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        gameManager.enemyController.EnemyAttack();
    }

    public void UseMoveTwo()
    {
        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 15;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.DefencePhase();
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(5, 10);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        gameManager.enemyController.EnemyAttack();
    }

    public void UseMoveThree()
    {
        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 20;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.DefencePhase();
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(10, 15);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        gameManager.enemyController.EnemyAttack();
    }
}
