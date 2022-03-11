using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickingPhase : MonoBehaviour
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
        int recoveryCheck = Random.Range(1, 101);

        //This will come from the move
        int recoveryChance = 10;

        int meters = resourceBars.startingMeters += Random.Range(25, 41);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        if (recoveryCheck < recoveryChance)
        {
            Debug.Log("YOU'VE RECOVERED THE BALL!");
            gameManager.AttackPhase();
            return;
        } else if (recoveryCheck > recoveryChance)
        {
            gameManager.DefencePhase();
        }
    }

    public void UseMoveTwo()
    {
        int recoveryCheck = Random.Range(1, 101);

        //This will come from the move
        int recoveryChance = 40;

        int meters = resourceBars.startingMeters += Random.Range(10, 16);
        resourceBars.ChangeMeters(meters);

        int fatigue = resourceBars.startingFatigue += 35;
        resourceBars.ChangeFatigue(fatigue);

        if (recoveryCheck < recoveryChance)
        {
            Debug.Log("YOU'VE RECOVERED THE BALL!");
            gameManager.AttackPhase();
            return;
        } else if (recoveryCheck > recoveryChance)
        {
            gameManager.DefencePhase();
        }
    }

    public void KickReturn()
    {
        gameManager.enemyController.EnemyAttack();
    }
}
