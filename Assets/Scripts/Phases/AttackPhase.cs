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
            gameManager.playerMatchText.text = "You look to find the gap in the defensive line, putting your head down and charging through the prop and flanker in front of you." +
                "As you take contact you feel the ball ripped from your grasp, and the opponent comes away with it. You turned the ball over.";
            gameManager.DefencePhase();
            return;
        }

        gameManager.playerMatchText.text = "You look to find the gap in the defensive line, putting your head down and charging through the prop and flanker in front of you." +
            "As you charge into contact, you breakthrough and are able to carry deep before the recovering no. 9 tackles you.";

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
            gameManager.playerMatchText.text = "You see a space behind the defensive line and decide to kick the ball over the top, looking to run on to it. You send the ball" +
                " high into the air and weave through opposition players in an attempt to catch it, but the opposing fullback gets there first! You turned the ball over.";

            int turnoverMeters = resourceBars.startingMeters += Random.Range(30, 41);
            resourceBars.ChangeMeters(turnoverMeters);

            int turnoverFatigue = resourceBars.startingFatigue += 30;
            resourceBars.ChangeFatigue(turnoverFatigue);

            gameManager.DefencePhase();
            return;
        }

        gameManager.playerMatchText.text = "You see a space behind the defensive line and decide to kick the ball over the top, looking to run on to it. You send the ball" +
            " high into the air and the fullback misjudges it, allowing you to get under it and take the catch.";

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
            gameManager.playerMatchText.text = "You cradle the ball in one arm and look at the defensive line ahead of you. Your opposition has a solid formation, so you " +
                "put your head down and charge in to make a few yards. As you slam into the opposition Lock, you feel the ball squeeze out of your arm and go forwards " +
                "hands of the opponent. You turn the ball over.";
            gameManager.DefencePhase();
            return;
        }

        gameManager.playerMatchText.text = "You cradle the ball in one arm and look at the defensive line ahead of you. Your opposition has a solid formation, so you " +
                "put your head down and charge in to make a few yards. As you slam into the opposition Lock, you're able to push him back a little and make some " +
                "ground.";

        int meters = resourceBars.startingMeters += Random.Range(5, 11);
        resourceBars.ChangeMeters(meters);

        int fatigue = resourceBars.startingFatigue += 5;
        resourceBars.ChangeFatigue(fatigue);

        gameManager.enemyController.EnemyAttack();
    }
}
