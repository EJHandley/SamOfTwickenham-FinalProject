using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Move", menuName = "Moves/Attack Move")]
public class AttackMoves : Moves
{
    public int minMeterGain;
    public int maxMeterGain;

    public int critMinMeterGain;
    public int critMaxMeterGain;

    public override void Use()
    {
        base.Use();
    }
}
