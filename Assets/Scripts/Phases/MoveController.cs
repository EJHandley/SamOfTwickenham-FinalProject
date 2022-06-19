using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    void Start()
    {
        
    }



    void Update()
    {
        
    }

    public void UseCoinTossMove(CoinTossMoves thisMove)
    {
        if(thisMove.type == "Choice")
        {
            GameManager.instance.CoinTossChoice(thisMove.style);
        }

        if(thisMove.type == "Winner")
        {
            GameManager.instance.CoinTossWon(thisMove.style);
        }
    }

    public void UseAttackMove(AttackMoves thisMove)
    {
        GameManager.instance.resourceBars.SetTime(thisMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
        {
            GameManager.instance.resourceBars.ChangeMeters(Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain));
        } 
        else if(successCheck < thisMove.criticalSuccess)
        {
            GameManager.instance.resourceBars.ChangeMeters(Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain));
        }

        GameManager.instance.resourceBars.ChangeFatigue(thisMove.fatigueCost);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
            thisMove.Turnover();
            return;
        }

        GameManager.instance.enemyCombat.PickDefence();
    }

    public void UseDefenceMove(DefenceMoves thisMove)
    {
        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
        {
            GameManager.instance.resourceBars.ChangeMeters(Random.Range(thisMove.minMeterStop, thisMove.maxMeterStop));
        }
        else if (successCheck < thisMove.criticalSuccess)
        {
            GameManager.instance.resourceBars.ChangeMeters(Random.Range(thisMove.critMinMeterStop, thisMove.critMaxMeterStop));
        }

        GameManager.instance.resourceBars.ChangeFatigue(thisMove.fatigueCost);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log("You rolled:" + successCheck + ". Move Failed. Foul!");
            thisMove.Foul();
            return;
        }

        GameManager.instance.enemyCombat.PickAttack();
    }

    public void UseKickMove(KickingMoves thisMove)
    {
        GameManager.instance.resourceBars.SetTime(thisMove.timeCost);

        int successCheck = Random.Range(1, 101);

        GameManager.instance.resourceBars.ChangeMeters(Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain));

        GameManager.instance.resourceBars.ChangeFatigue(thisMove.fatigueCost);

        if (successCheck <= thisMove.successChance)
        {
            Debug.Log("YOU'VE RECOVERED THE BALL!");
            return;
        }

        thisMove.Turnover();

        GameManager.instance.enemyCombat.KickReturn();
    }
}
