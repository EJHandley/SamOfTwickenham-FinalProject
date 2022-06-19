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
        GameManager.instance.resourceBars.SetTime(enemyMove.timeCost);

        int successCheck = Random.Range(1, 101);

        if (successCheck > enemyMove.criticalSuccess && successCheck <= enemyMove.successChance)
        {
            GameManager.instance.resourceBars.ChangeMeters(-Random.Range(enemyMove.minMeterGain, enemyMove.maxMeterGain));
        }
        else if (successCheck < enemyMove.criticalSuccess)
        {
            GameManager.instance.resourceBars.ChangeMeters(-Random.Range(enemyMove.critMinMeterGain, enemyMove.critMaxMeterGain));
        }

        GameManager.instance.resourceBars.ChangeFatigue(-enemyMove.fatigueCost);

        if (successCheck > enemyMove.successChance)
        {
            Debug.Log("You rolled:" + successCheck + ". Move Failed. Turnover!");
            enemyMove.Turnover();
            return;
        }
    }

    public void EnemyDefenceMove(DefenceMoves enemyMove)
    {

    }

    public void EnemyKickMove(KickingMoves enemyMove)
    {

    }

    public void EnemyKickReturn(KickingMoves enemyMove)
    {

    }
}
