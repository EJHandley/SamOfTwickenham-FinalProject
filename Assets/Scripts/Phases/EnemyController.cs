using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CoinTossWon()
    {
        int coinTossChoice = Random.Range(1, 101);

        if (coinTossChoice <= 80)
        {
            GameManager.instance.SetMoveFeedback("your opponent chose to attack first", "Opponent");
            GameManager.instance.ChangePhase("Kicking Phase");
        }
        else if (coinTossChoice > 80)
        {
            GameManager.instance.SetMoveFeedback("your opponent chose to defend first", "Opponent");
            GameManager.instance.ChangePhase("Kick Return");
        }
    }

    public void EnemyAttackMove(AttackMoves enemyMove)
    {
        GameManager.instance.SetMoveFeedback("your opponent used " + enemyMove.name, "Opponent");

        GameManager.instance.timeManager.SetTime(enemyMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if(enemyMove.style == "Ground")
        {
            GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);

            if (successCheck > enemyMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! they turned the ball over", "Opponent");
                enemyMove.Turnover("Enemy");
                return;
            }

            if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
            {
                int meterChange = Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
                GameManager.instance.SetMoveFeedback("opponent made " + meterChange.ToString() + " meters", "Opponent");
            }
            else if (successCheck < enemyMove.criticalSuccess)
            {
                int critMeterChange = (Random.Range(enemyMove.critMinMeterGain, enemyMove.critMaxMeterGain));
                GameManager.instance.resourceBars.ChangeMeters("Enemy", critMeterChange);
                GameManager.instance.SetMoveFeedback("crit! opponent made " + critMeterChange.ToString() + " meters", "Opponent");
            }
        }

        if(enemyMove.style == "Kick")
        {
            int meterChange = Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
            GameManager.instance.SetMoveFeedback("opponent kicked it " + meterChange.ToString() + " meters", "Opponent");

            GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);

            if (successCheck > enemyMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! they turned the ball over", "Opponent");
                enemyMove.Turnover("Enemy");
                return;
            }
            else if (successCheck <= enemyMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move succeeded! they recovered the ball", "Opponent");
                enemyMove.Recover("Enemy");
            }

        }

    }

    public void EnemyDefenceMove(DefenceMoves enemyMove)
    {
        GameManager.instance.SetMoveFeedback("your opponent used " + enemyMove.name, "Opponent");

        int successCheck = Random.Range(1, 101);

        if (successCheck > enemyMove.successChance)
        {
            GameManager.instance.SetMoveFeedback("move failed! they committed a foul", "Opponent");
            enemyMove.Foul("Enemy");
            return;
        }

        if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
        {
            int meterChange = (Random.Range(enemyMove.minMeterStop, enemyMove.maxMeterStop));
            GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
            GameManager.instance.SetMoveFeedback("they pushed you back " + meterChange.ToString() + " meters", "Opponent");
        }
        else if (successCheck < enemyMove.criticalSuccess)
        {
            int critMeterChange = Random.Range(enemyMove.critMinMeterStop, enemyMove.critMaxMeterStop);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", critMeterChange);
            GameManager.instance.SetMoveFeedback("they pushed you back " + critMeterChange.ToString() + " meters", "Opponent");
        }

        GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);
    }

    public void EnemyKickMove(KickingMoves enemyMove)
    {
        GameManager.instance.SetMoveFeedback("your opponent used " + enemyMove.name, "Opponent");

        GameManager.instance.timeManager.SetTime(enemyMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if(enemyMove.style == "Normal")
        { 
            GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);

            int meterChange = Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
            GameManager.instance.SetMoveFeedback("opponent kicked it " + meterChange.ToString() + " meters", "Opponent");

            if (successCheck > enemyMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! they turned the ball over", "Opponent");
                GameManager.instance.ChangePhase("Attack Phase");
                return;
            }
            else if (successCheck <= enemyMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move succeeded! they recovered the ball", "Opponent");
                enemyMove.Recover("Enemy");
                return;
            }
        }

        if (enemyMove.style == "Return")
        {
            if(successCheck > enemyMove.successChance)
            {
                GameManager.instance.SetMoveFeedback("move failed! they turned the ball over", "Opponent");
                enemyMove.Turnover("Enemy");
                return;
            }

            if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
            {
                int meterChange = Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
                GameManager.instance.SetMoveFeedback("opponent made " + meterChange.ToString() + " meters", "Opponent");
            }
            else if (successCheck < enemyMove.criticalSuccess)
            {
                int critMeterChange = Random.Range(enemyMove.critMinMeterGain, enemyMove.critMaxMeterGain);
                GameManager.instance.resourceBars.ChangeMeters("Enemy", critMeterChange);
                GameManager.instance.SetMoveFeedback("opponent made " + critMeterChange.ToString() + " meters", "Opponent");
            }

            GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);

            GameManager.instance.ChangePhase("Defence Phase");
        }
    }
}
