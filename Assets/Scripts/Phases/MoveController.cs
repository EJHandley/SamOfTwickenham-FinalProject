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
        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log(successCheck);
            Debug.Log("TURNOVER");
            thisMove.Turnover();
            return;
        }

        if(successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
        {
            int meters = resourceBars.startingMeters += Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
            resourceBars.ChangeMeters(meters);
            Debug.Log(meters);
        } 
        else if(successCheck < thisMove.criticalSuccess)
        {
            int meters = resourceBars.startingMeters += Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain);
            resourceBars.ChangeMeters(meters);
            Debug.Log(meters);
        }

        int fatigue = resourceBars.startingFatigue += thisMove.fatigueCost;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);

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

        int meters = resourceBars.startingMeters += Random.Range(thisMove.minMeterStop, thisMove.maxMeterStop);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += thisMove.fatigueCost;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
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
