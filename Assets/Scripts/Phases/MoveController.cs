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

        if(thisMove.style == "Ground")
        {
            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            if (successCheck > thisMove.successChance)
            {
                Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
                thisMove.Turnover("Player");
                return;
            }

            if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
            {
                int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
                Debug.Log("HIT! You made " + meterChange + " meters!");
            }
            else if (successCheck < thisMove.criticalSuccess)
            {
                int critMeterChange = Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", critMeterChange);
                Debug.Log("CRIT! You made " + critMeterChange + " meters!");
            }
        }

        if(thisMove.style == "Kick")
        {
            int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
            Debug.Log("HIT! You made " + meterChange + " meters!");

            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            if (successCheck > thisMove.successChance)
            {
                Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
                thisMove.Turnover("Player");
                return;
            }
            else if (successCheck <= thisMove.successChance)
            {
                thisMove.Recover("Player");
            }
        }

        GameManager.instance.enemyCombat.PickDefence();
    }

    public void UseDefenceMove(DefenceMoves thisMove)
    {
        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.successChance)
        {
            Debug.Log("You rolled:" + successCheck + ". Move Failed. Foul!");
            thisMove.Foul("Player");
            return;
        }

        if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
        {
            int meterChange = Random.Range(thisMove.minMeterStop, thisMove.maxMeterStop);
            GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
            Debug.Log("HIT! You pushed them back " + meterChange + " meters!");
        }
        else if (successCheck < thisMove.criticalSuccess)
        {
            int critMeterChange = Random.Range(thisMove.critMinMeterStop, thisMove.critMaxMeterStop);
            GameManager.instance.resourceBars.ChangeMeters("Player", critMeterChange);
            Debug.Log("CRIT! You pushed them back " + critMeterChange + " meters!");
        }

        GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

        GameManager.instance.enemyCombat.PickAttack();
    }

    public void UseKickMove(KickingMoves thisMove)
    {
        Debug.Log("You Used " + thisMove.name);
        
        GameManager.instance.resourceBars.SetTime(thisMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if(thisMove.style == "Normal")
        {
            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
            Debug.Log("HIT! You made " + meterChange + " meters!");

            if (successCheck > thisMove.successChance)
            {
                Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
                thisMove.Turnover("Player");
                GameManager.instance.enemyCombat.KickReturn();
                return;
            }
            else if (successCheck <= thisMove.successChance)
            {
                thisMove.Recover("Player");
                GameManager.instance.enemyCombat.PickDefence();
                return;
            }
        }

        if(thisMove.style == "Return")
        {
            if (successCheck > thisMove.successChance)
            {
                thisMove.Turnover("Player");
                return;
            }

            if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
            {
                int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
                Debug.Log("HIT! You kicked it " + meterChange + " meters!");
            }
            else if (successCheck < thisMove.criticalSuccess)
            {
                int critMeterChange = Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", critMeterChange);
                Debug.Log("CRIT! You kicked it " + critMeterChange + " meters!");
            }

            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            GameManager.instance.enemyCombat.PickKick();
        }
    }
}
