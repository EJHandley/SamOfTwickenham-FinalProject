using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Move", menuName = "Moves/Attack Move")]
public class AttackMoves : Moves
{
    [Header("Time")]
    public float timeCost;

    [Header("Meter Changes")]
    public int minMeterGain;
    public int maxMeterGain;

    [Header("Critical Meter Changes")]
    public int critMinMeterGain;
    public int critMaxMeterGain;

    public override void Turnover()
    {
        base.Turnover();
    }

    public override void Use()
    {
        base.Use();
    }
}
