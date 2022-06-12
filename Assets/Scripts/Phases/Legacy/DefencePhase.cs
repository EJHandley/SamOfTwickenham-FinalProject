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
        gameManager.enemyController.EnemyAttack();

        if (resourceBars.meterFill.value <= 0)
            return;

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
    }

    public void UseMoveTwo()
    {
        gameManager.enemyController.EnemyAttack();

        if (resourceBars.meterFill.value <= 0)
            return;

        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 15;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.playerMatchText.text = "As your teammate makes the tackle, you follow up, getting yourself over the ball and attempting to rip it from the ball carriers grip. You hear the shrill " +
                "whine of the whistle as the referee says you were off your feet. You've committed a foul (Fouls not yet implemented).";
            gameManager.DefencePhase();
            return;
        }

        gameManager.playerMatchText.text = "As your teammate makes the tackle, you follow up, getting yourself over the ball and attempting to rip it from the ball carriers grip. You aren't able to take " +
            "control of the ball, but your efforts slow down the opponent and force them to reset their offence.";

        int meters = resourceBars.startingMeters += Random.Range(5, 10);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
    }

    public void UseMoveThree()
    {
        gameManager.enemyController.EnemyAttack();

        if (resourceBars.meterFill.value <= 0)
            return;

        int foulCheck = Random.Range(1, 101);

        //This will come from the move
        int foulChance = 20;

        if (foulCheck < foulChance)
        {
            Debug.Log("FOUL");
            gameManager.playerMatchText.text = "The opposition winger flys forward as he catches the pass, and looks to drive past your lines. You square up and go in hard to drive the winger backwards " +
                "but the referee blows up and tells you you've hit them too high. You've committed a foul (Fouls not yet implemented).";
            gameManager.DefencePhase();
            return;
        }

        gameManager.playerMatchText.text = "The opposition winger flys forward as he catches the pass, and looks to drive past your lines. You square up and go in hard, driving the winger backwards " +
            "and stopping their attack dead in it's tracks.";

        int meters = resourceBars.startingMeters += Random.Range(10, 15);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
    }
}
