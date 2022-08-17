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
            GameManager.instance.SetMoveFeedback("you " + thisMove.name, "Player");
            GameManager.instance.CoinTossChoice(thisMove.style);
        }

        if(thisMove.type == "Winner")
        {
            GameManager.instance.SetMoveFeedback("you chose to " + thisMove.name, "Player");
            GameManager.instance.CoinTossWon(thisMove.style);
        }
    }

    public void UseAttackMove(AttackMoves thisMove)
    {
        GameManager.instance.timeManager.SetTime(thisMove.timeCost);

        GameManager.instance.SetMoveFeedback("you used " + thisMove.name, "Player");

        int successCheck = Random.Range(1, 101);

        if(thisMove.style == "Ground")
        {
            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            if (successCheck > thisMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! you turned the ball over", "Player");
                thisMove.Turnover("Player");
                return;
            }

            if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
            {
                int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
                GameManager.instance.SetMoveFeedback("you made " + meterChange.ToString() + " meters", "Player");
            }
            else if (successCheck < thisMove.criticalSuccess)
            {
                int critMeterChange = Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", critMeterChange);
                GameManager.instance.SetMoveFeedback("crit! you made " + critMeterChange.ToString() + " meters", "Player");
            }
        }

        if(thisMove.style == "Kick")
        {          
            int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
            GameManager.instance.SetMoveFeedback("you kicked it " + meterChange.ToString() + " meters", "Player");

            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            if (successCheck > thisMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! you turned the ball over", "Player");
                thisMove.Turnover("Player");
                return;
            }
            else if (successCheck <= thisMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("moved succeeded! you recover the ball", "Player");
                thisMove.Recover("Player");
            }
        }

        GameManager.instance.enemyCombat.PickDefence();
    }

    public void UseDefenceMove(DefenceMoves thisMove)
    {
        GameManager.instance.SetMoveFeedback("you used " + thisMove.name, "Player");

        int successCheck = Random.Range(1, 101);

        if (successCheck > thisMove.successChance)
        {
            GameManager.instance.SetMoveFeedback("move failed! you commit a foul", "Player");
            thisMove.Foul("Player");
            return;
        }

        if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
        {
            int meterChange = Random.Range(thisMove.minMeterStop, thisMove.maxMeterStop);
            GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
            GameManager.instance.SetMoveFeedback("you pushed them back " + meterChange.ToString() + " meters", "Player");
        }
        else if (successCheck < thisMove.criticalSuccess)
        {
            int critMeterChange = Random.Range(thisMove.critMinMeterStop, thisMove.critMaxMeterStop);
            GameManager.instance.resourceBars.ChangeMeters("Player", critMeterChange);
            GameManager.instance.SetMoveFeedback("crit! you pushed them back " + critMeterChange.ToString() + " meters", "Player");
        }

        GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

        GameManager.instance.enemyCombat.PickAttack();
    }

    public void UseKickMove(KickingMoves thisMove)
    {
        GameManager.instance.SetMoveFeedback("you used " + thisMove.name, "Player");

        GameManager.instance.timeManager.SetTime(thisMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if(thisMove.style == "Normal")
        {
            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
            GameManager.instance.SetMoveFeedback("you kicked it " + meterChange.ToString() + " meters", "Player");

            if (successCheck > thisMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! you turned the ball over", "Player");
                thisMove.Turnover("Player");
                GameManager.instance.enemyCombat.KickReturn();
                return;
            }
            else if (successCheck <= thisMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("moved succeeded! you recover the ball", "Player");
                thisMove.Recover("Player");
                GameManager.instance.enemyCombat.PickDefence();
                return;
            }
        }

        if(thisMove.style == "Return")
        {
            if (successCheck > thisMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! you turned the ball over", "Player");
                thisMove.Turnover("Player");
                return;
            }

            if (successCheck > thisMove.criticalSuccess && successCheck <= thisMove.successChance)
            {
                int meterChange = Random.Range(thisMove.minMeterGain, thisMove.maxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", meterChange);
                GameManager.instance.SetMoveFeedback("you made " + meterChange.ToString() + " meters", "Player");
            }
            else if (successCheck < thisMove.criticalSuccess)
            {
                int critMeterChange = Random.Range(thisMove.critMinMeterGain, thisMove.critMaxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Player", critMeterChange);
                GameManager.instance.SetMoveFeedback("crit! you made " + critMeterChange.ToString() + " meters", "Player");
            }

            GameManager.instance.resourceBars.ChangeFatigue("Player", thisMove.fatigueCost);

            GameManager.instance.enemyCombat.PickKick();
        }
    }
}
