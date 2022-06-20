using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defence Move", menuName = "Moves/Defence Move")]
public class DefenceMoves : Moves
{
    public int minMeterStop;
    public int maxMeterStop;

    public int critMinMeterStop;
    public int critMaxMeterStop;

    public override void Foul(string user)
    {
        base.Foul(user);
    }

    public override void Use()
    {
        base.Use();
    }
}
