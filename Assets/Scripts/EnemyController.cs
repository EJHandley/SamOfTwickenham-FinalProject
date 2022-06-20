﻿using System.Collections;
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
            GameManager.instance.ChangePhase("Kicking Phase");
        }
        else if (coinTossChoice > 80)
        {
            GameManager.instance.ChangePhase("Kick Return");
        }
    }

    public void EnemyAttackMove(AttackMoves enemyMove)
    {
        Debug.Log("The Opposition Used " + enemyMove.name);

        GameManager.instance.resourceBars.SetTime(enemyMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if (successCheck > enemyMove.successChance)
        {
            Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
            enemyMove.Turnover();
            return;
        }

        if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
        {
            int meterChange = Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
            Debug.Log("HIT! The Opposition made " + meterChange + " meters!");
        }
        else if (successCheck < enemyMove.criticalSuccess)
        {
            int critMeterChange = (Random.Range(enemyMove.critMinMeterGain, enemyMove.critMaxMeterGain));
            GameManager.instance.resourceBars.ChangeMeters("Enemy", critMeterChange);
            Debug.Log("CRIT! The Opposition made " + critMeterChange + " meters!");
        }

        GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);
    }

    public void EnemyDefenceMove(DefenceMoves enemyMove)
    {
        Debug.Log("The Opposition Used " + enemyMove.name);

        int successCheck = Random.Range(1, 101);

        if (successCheck > enemyMove.successChance)
        {
            Debug.Log("You rolled:" + successCheck + ". Move Failed. Foul!");
            enemyMove.Foul();
            return;
        }

        if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
        {
            int meterChange = (Random.Range(enemyMove.minMeterStop, enemyMove.maxMeterStop));
            GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
            Debug.Log("HIT! The Opposition pushed you back " + meterChange + " meters!");
        }
        else if (successCheck < enemyMove.criticalSuccess)
        {
            int critMeterChange = Random.Range(enemyMove.critMinMeterStop, enemyMove.critMaxMeterStop);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", critMeterChange);
            Debug.Log("CRIT! The Opposition pushed you back " + critMeterChange + " meters!");
        }

        GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);
    }

    public void EnemyKickMove(KickingMoves enemyMove)
    {
        Debug.Log("The Opposition Used " + enemyMove.name);

        GameManager.instance.resourceBars.SetTime(enemyMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
        {
            int meterChange = Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", meterChange);
            Debug.Log("HIT! The Opposition kicked it " + meterChange + " meters!");
        }
        else if (successCheck < enemyMove.criticalSuccess)
        {
            int critMeterChange = Random.Range(enemyMove.critMinMeterGain, enemyMove.critMaxMeterGain);
            GameManager.instance.resourceBars.ChangeMeters("Enemy", critMeterChange);
            Debug.Log("CRIT! The Opposition kicked it " + critMeterChange + " meters!");
        }

        GameManager.instance.resourceBars.ChangeFatigue("Enemy", enemyMove.fatigueCost);

        if (enemyMove.style == "Normal")
        {
            if (successCheck > enemyMove.successChance)
            {
                Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
                GameManager.instance.ChangePhase("Attack Phase");
                return;
            }
            else if (successCheck <= enemyMove.successChance)
            {
                enemyMove.Recover();
                return;
            }
        }

        if (enemyMove.style == "Return")
        {
            if(successCheck > enemyMove.successChance)
            {
                enemyMove.Turnover();
            }
            else if (successCheck <= enemyMove.successChance)
            {
                GameManager.instance.ChangePhase("Defence Phase");
            }
        }
    }
}
