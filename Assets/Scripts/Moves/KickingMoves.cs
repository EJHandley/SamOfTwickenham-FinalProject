using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Kicking Move", menuName = "Moves/Kicking Move")]
public class KickingMoves : Moves
{
    public float timeCost;

    public int minMeterGain;
    public int maxMeterGain;

    public int critMinMeterGain;
    public int critMaxMeterGain;

    public override void Recover(string user)
    {
        base.Recover(user);
    }

    public override void Use()
    {
        base.Use();
    }
}
