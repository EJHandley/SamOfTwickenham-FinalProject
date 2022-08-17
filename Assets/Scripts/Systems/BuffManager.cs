using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuffManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public MoveList starMoves;
    public MoveList teamMoves;

    [HideInInspector] public List<AttackMoves> starAttackMoves;
    [HideInInspector] public List<DefenceMoves> starDefenceMoves;

    [HideInInspector] public List<AttackMoves> teamAttackMoves;
    [HideInInspector] public List<DefenceMoves> teamDefenceMoves;

    [Header("Buff Tracking Text")]
    public GameObject minEgoBuff;
    public GameObject maxEgoBuff;
    public GameObject minTMBuff;
    public GameObject maxTMBuff;

    void Start()
    {
        foreach (Moves move in starMoves.moves)
        {
            if (move.phase == "Attack Phase")
            {
                starAttackMoves.Add((AttackMoves)move);
            }
            else if (move.phase == "Defence Phase")
            {
                starDefenceMoves.Add((DefenceMoves)move);
            }
        }

        foreach (Moves move in teamMoves.moves)
        {
            if (move.phase == "Attack Phase")
            {
                teamAttackMoves.Add((AttackMoves)move);
            }
            else if (move.phase == "Defence Phase")
            {
                teamDefenceMoves.Add((DefenceMoves)move);
            }
        }

        StatCheck();
    }

    void Update()
    {

    }

    public void TestCheck()
    {
        playerStats.egoValue += 50;
        playerStats.teamValue += 50;

        StatCheck();
    }

    public void StatCheck()
    {
        if (playerStats.egoValue < 60 && playerStats.teamValue < 60)
        {
            NoBuffs();
        }

        if (playerStats.egoValue >= 60 && playerStats.egoValue < 70)
        {
            if(minEgoBuff != null)
            {
                minEgoBuff.SetActive(true);
            }

            StarMinorBuff();
        }

        if (playerStats.egoValue >= 70)
        {
            if(maxEgoBuff != null)
            {
                maxEgoBuff.SetActive(true);
            }

            StarMaxBuff();
        }

        if (playerStats.teamValue >= 60 && playerStats.teamValue < 70)
        {
            if(minTMBuff != null)
            {
                minTMBuff.SetActive(true);
            }

            TeamMinorBuff();
        }

        if (playerStats.teamValue >= 70)
        {
            if(maxTMBuff != null)
            {
                maxTMBuff.SetActive(true);
            }

            TeamMaxBuff();
        }
    }

    public void NoBuffs()
    {
        #region StarMoves
        foreach (AttackMoves move in starAttackMoves)
        {
            move.successChance = move.baseSuccess + 0;

            move.minMeterGain = move.baseMinGain + 0;
            move.maxMeterGain = move.baseMaxGain + 0;

            move.criticalSuccess = move.baseCrit + 0;

            move.critMinMeterGain = move.baseCritMin + 0;
            move.critMaxMeterGain = move.baseCritMax + 0;

            move.fatigueCost = move.baseFatigue - 0;
        }

        foreach (DefenceMoves move in starDefenceMoves)
        {
            move.successChance = move.baseSuccess + 0;

            move.minMeterStop = move.baseMinStop + 0;
            move.maxMeterStop = move.baseMaxStop + 0;

            move.criticalSuccess = move.baseCrit + 0;

            move.critMinMeterStop = move.baseCritMin + 0;
            move.critMaxMeterStop = move.baseCritMax + 0;

            move.fatigueCost = move.baseFatigue - 0;
        }
        #endregion

        #region TeamMoves
        foreach (AttackMoves move in teamAttackMoves)
        {
            move.successChance = move.baseSuccess + 0;

            move.minMeterGain = move.baseMinGain + 0;
            move.maxMeterGain = move.baseMaxGain + 0;

            move.criticalSuccess = move.baseCrit + 0;

            move.critMinMeterGain = move.baseCritMin + 0;
            move.critMaxMeterGain = move.baseCritMax + 0;

            move.fatigueCost = move.baseFatigue - 0;
        }

        foreach (DefenceMoves move in teamDefenceMoves)
        {
            move.successChance = move.baseSuccess + 0;

            move.minMeterStop = move.baseMinStop + 0;
            move.maxMeterStop = move.baseMaxStop + 0;

            move.criticalSuccess = move.baseCrit + 0;

            move.critMinMeterStop = move.baseCritMin + 0;
            move.critMaxMeterStop = move.baseCritMax + 0;

            move.fatigueCost = move.baseFatigue - 0;
        }
        #endregion
    }

    public void StarMinorBuff()
    {
        foreach (AttackMoves move in starAttackMoves)
        {
            move.successChance = move.baseSuccess + 2;

            move.minMeterGain = move.baseMinGain + 1;
            move.maxMeterGain = move.baseMaxGain + 1;

            move.criticalSuccess = move.baseCrit + 2;

            move.critMinMeterGain = move.baseCritMin + 1;
            move.critMaxMeterGain = move.baseCritMax + 1;

            move.fatigueCost = move.baseFatigue - 2;
        }

        foreach (DefenceMoves move in starDefenceMoves)
        {
            move.successChance = move.baseSuccess + 2;

            move.minMeterStop = move.baseMinStop + 1;
            move.maxMeterStop = move.baseMaxStop + 1;

            move.criticalSuccess = move.baseCrit + 2;

            move.critMinMeterStop = move.baseCritMin + 1;
            move.critMaxMeterStop = move.baseCritMax + 1;

            move.fatigueCost = move.baseFatigue - 2;
        }
    }

    public void StarMaxBuff()
    {
        foreach (AttackMoves move in starAttackMoves)
        {
            move.successChance = move.baseSuccess + 5;

            move.minMeterGain = move.baseMinGain + 3;
            move.maxMeterGain = move.baseMaxGain + 3;

            move.criticalSuccess = move.baseCrit + 5;

            move.critMinMeterGain = move.baseCritMin + 3;
            move.critMaxMeterGain = move.baseCritMax + 3;

            move.fatigueCost = move.baseFatigue - 5;
        }

        foreach (DefenceMoves move in starDefenceMoves)
        {
            move.successChance = move.baseSuccess + 5;

            move.minMeterStop = move.baseMinStop + 3;
            move.maxMeterStop = move.baseMaxStop + 3;

            move.criticalSuccess = move.baseCrit + 5;

            move.critMinMeterStop = move.baseCritMin + 3;
            move.critMaxMeterStop = move.baseCritMax + 3;

            move.fatigueCost = move.baseFatigue - 5;
        }
    }

    public void TeamMinorBuff()
    {
        foreach (AttackMoves move in teamAttackMoves)
        {
            move.successChance = move.baseSuccess + 2;

            move.minMeterGain = move.baseMinGain + 1;
            move.maxMeterGain = move.baseMaxGain + 1;

            move.criticalSuccess = move.baseCrit + 2;

            move.critMinMeterGain = move.baseCritMin + 1;
            move.critMaxMeterGain = move.baseCritMax + 1;

            move.fatigueCost = move.baseFatigue - 2;
        }

        foreach (DefenceMoves move in teamDefenceMoves)
        {
            move.successChance = move.baseSuccess + 2;

            move.minMeterStop = move.baseMinStop + 1;
            move.maxMeterStop = move.baseMaxStop + 1;

            move.criticalSuccess = move.baseCrit + 2;

            move.critMinMeterStop = move.baseCritMin + 1;
            move.critMaxMeterStop = move.baseCritMax + 1;

            move.fatigueCost = move.baseFatigue - 2;
        }
    }

    public void TeamMaxBuff()
    {
        foreach (AttackMoves move in teamAttackMoves)
        {
            move.successChance = (move.baseSuccess + 5);

            move.minMeterGain = move.baseMinGain + 3;
            move.maxMeterGain = move.baseMaxGain + 3;

            move.criticalSuccess = move.baseCrit + 5;

            move.critMinMeterGain = move.baseCritMin + 3;
            move.critMaxMeterGain = move.baseCritMax + 3;

            move.fatigueCost = move.baseFatigue - 5;
        }

        foreach (DefenceMoves move in teamDefenceMoves)
        {
            move.successChance = move.baseSuccess + 5;

            move.minMeterStop = move.baseMinStop + 3;
            move.maxMeterStop = move.baseMaxStop + 3;

            move.criticalSuccess = move.baseCrit + 5;

            move.critMinMeterStop = move.baseCritMin + 3;
            move.critMaxMeterStop = move.baseCritMax + 3;

            move.fatigueCost = move.baseFatigue - 5;
        }
    }
}