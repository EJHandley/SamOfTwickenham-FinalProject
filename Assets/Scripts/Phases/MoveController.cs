using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public ResourceBars resourceBars;
    public GameManager gameManager;

    void Start()
    {
        
    }



    void Update()
    {
        
    }


    public void UseAttackMove(AttackMoves thisMove)
    {
        resourceBars.SetTime(thisMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log(successCheck);
            Debug.Log("TURNOVER");
            thisMove.Turnover();
            return;
        }

        if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
        {
            resourceBars.ChangeMeters(Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain));
        } 
        else if(successCheck < thisMove.criticalSuccess)
        {
            resourceBars.ChangeMeters(Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain));
        }

        resourceBars.ChangeFatigue(thisMove.fatigueCost);
    }

    public void UseDefenceMove(DefenceMoves thisMove)
    {
        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log(successCheck);
            Debug.Log("FOUL");
            return;
        }

        resourceBars.ChangeMeters(Random.Range(thisMove.minMeterStop, thisMove.maxMeterStop));

        resourceBars.ChangeFatigue(thisMove.fatigueCost);
    }

    public void UseKickMove(KickingMoves thisMove)
    {
        int successCheck = Random.Range(1, 101);

        int meters = resourceBars.startingMeters += Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 20;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log("YOU'VE RECOVERED THE BALL!");
            return;
        }
    }
}
