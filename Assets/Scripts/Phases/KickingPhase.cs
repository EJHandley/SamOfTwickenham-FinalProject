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

        int fatigue = resourceBars.startingFatigue += 20;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        if (recoveryCheck < recoveryChance)
        {
            Debug.Log("YOU'VE RECOVERED THE BALL!");
            gameManager.playerMatchText.text = "You kick it deep into the opposition half, with the wingers flying after your long punt. As the ball comes down it slips between the arms of the fly-half and " +
                "takes a lucky bounce backwards. Your teammate scoops the ball off the ground and is swiftly tackled for his struggles.";
            gameManager.AttackPhase();
            return;
        } 
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.playerMatchText.text = "You kick it deep into the opposition half, with the wingers flying after your long punt. As the ball comes down the scrum-half positions themselves underneath " +
                "and takes a neat catch before your teammate smothers him in a tackle.";
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
            gameManager.playerMatchText.text = "Despite the risks, or maybe because of them, you kick the ball short. It barely goes the minimum ten meters before it begins to bobble and cause chaos amongst the " +
                "forwards. As it takes another wild bounce it sits up just nicely for your on rushing hooker who snatches the ball out of the air and goes to ground.";
            gameManager.AttackPhase();
            return;
        } 
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.playerMatchText.text = "Despite the risks, or maybe because of them, you kick the ball short. It barely goes the minimum ten meters before it begins to bobble and cause chaos amongst the " +
                "forwards. Despite your teams best efforts, the opposition comes away with the ball.";
            gameManager.DefencePhase();
        }
    }

    public void KickReturn()
    {
        gameManager.playerMatchText.text = "You point and jostle your teammates into formation as the opposition lines up on the half way line. The opposition kicker takes a moment to complete the usual ritual " +
            "before the referee's whistle rings out and you see the ball leave his boot.";
        gameManager.enemyController.EnemyAttack();
    }
}
