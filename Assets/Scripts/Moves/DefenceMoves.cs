using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defence Move", menuName = "Moves/Defence Move")]
public class DefenceMoves : Moves
{
    [Header("Meter Changes")]
    public int minMeterStop;
    public int maxMeterStop;

    [Header("Critical Meter Changes")]
    public int critMinMeterStop;
    public int critMaxMeterStop;

    [Header("For Buff System")]
    public int baseMinStop;
    public int baseMaxStop;
    public int baseCritMin;
    public int baseCritMax;

    public override void Foul(string user)
    {
        base.Foul(user);
    }

    public override void Use()
    {
        base.Use();
    }
}
