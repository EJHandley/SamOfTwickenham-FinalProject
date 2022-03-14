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
            gameManager.oppoMatchText.text = "The opponent kicks the ball deep into your half, and you line up to collect and begin your march towards the try line. As the ball comes down it takes a slight " +
                "move in the breeze and your fullback misses it as it comes down. The opposition winger sweeps and dives onto the ball. The opponent has recovered the ball.";
            gameManager.DefencePhase();
            return;
        }
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.oppoMatchText.text = "The opponent kicks the ball deep into your half, and you line up to collect and begin your march towards the try line. It comes down in a sweet spiral and you " +
                "take the catch, before charging a few yards into contact.";
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
            Debug.Log("OPPONENT RECOVERED THE BALL!");
            gameManager.oppoMatchText.text = "The opponent takes a short kick and you see their entire line bear down as it bobbles across the ten meter line. Your prop attempts to snatch it off the turf " +
                "but he fumbles it and the opposition no. 9 scoops up the loose ball. The opponent has recovered the ball.";
            gameManager.DefencePhase();
            return;
        }
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.oppoMatchText.text = "The opponent takes a short kick and you see their entire line bear down as it bobbles across the ten meter line. Your prop snatches it up off the turf " +
                "and barrels into the opposition no. 9 as he charges forward.";
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
            gameManager.oppoMatchText.text = "Your opponent bears down on your defensive line, head down and charging in. As they slam into you, the ball pops out and you are able to " +
                "collect it. The opposition turn the ball over.";
            gameManager.AttackPhase();
            return;
        }

        gameManager.oppoMatchText.text = "Your opponent bears down on your defensive line, head down and charging in. As they slam into you feel their legs driving them forward and you " +
            "to find grip on the slippery field below.";

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
            gameManager.oppoMatchText.text = "Your opponent flys towards a gap in your defensive line, stepping left and right as they look for the way through. As they slide betweeen " +
                "you and the prop to your left, you get a hand to the ball and rip it from their grasp. The opposition turn the ball over.";
            gameManager.AttackPhase();
            return;
        }

        gameManager.oppoMatchText.text = "Your opponent flys towards a gap in your defensive line, stepping left and right as they look for the way through. As they slide betweeen " +
            "you and the prop to your left, you prepare to make the tackle.";

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

            gameManager.oppoMatchText.text = "Your opponent puts a high kick up into the air over your defensive line, and takes off in pursuit of the ball. As it spirals downwards, " +
                "your fullback adjusts his position and catches the ball neatly before being tackled. The opposition turn the ball over.";
            gameManager.AttackPhase();
            return;
        }

        gameManager.oppoMatchText.text = "Your opponent puts a high kick up into the air over your defensive line, and takes off in pursuit of the ball. As it spirals downwards, " +
            "your fullback loses sight of it for a brief second and it drops past him, taking a bounce before being scooped up by the opposition fly-half.";

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
            gameManager.oppoMatchText.text = "Your opponent sights you coming and prepares to wrap you up. As they make contact you feel a collision with your chest and the referee's whistle sounds out. " +
                "The opponent commits a foul. (Fouls not yet implemented).";
            gameManager.DefencePhase();
            return;
        }

        gameManager.oppoMatchText.text = "Your opponent sights you coming and prepares to wrap you up. As they make contact you feel the collision on your hip and you go to ground. " +
            "The opponent rucks over and you prepare to start the offence again.";

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
            gameManager.oppoMatchText.text = "Your opponent sees you go down in contact and is straight over you, bucket-like hands reaching towards the ball. In their enthusiam, those giant hands hit " +
                "the pitch and the referee calls the foul. The opponent commits a foul. (Fouls not yet implemented).";
            gameManager.DefencePhase();
            return;
        }

        gameManager.oppoMatchText.text = "Your opponent sees you go down in contact and is straight over you, bucket-like hands reaching towards the ball. They get a touch, and hold on as tight as possible " +
            "but they only succeed in slowing you down slightly.";

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
            gameManager.oppoMatchText.text = "As you drive forward, the opposition flys out of their line and bears down on you, legs pumping as they slam into you at speed. As they tackle you their arm slips up " +
                "and you feel it wrap your neck as you hit the ground. The whistle calls and the referee's arm swings out to call the foul for the high tackle. The opponent commits a foul. (Fouls not yet implemented).";
            gameManager.DefencePhase();
            return;
        }

        gameManager.oppoMatchText.text = "As you drive forward, the opposition flys out of their line and bears down on you, legs pumping as they slam into you at speed. As they tackle you, you feel the power " +
            "behind the hit and you struggle to power forward. Your weight tips and you are driven backwards.";

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
