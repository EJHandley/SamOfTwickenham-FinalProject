using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defence Move", menuName = "Moves/Defence Move")]
public class DefenceMoves : Moves
{


    public int metersStopped;
    public float foulChance;

    public override void Use()
    {
        base.Use();
    }


}
