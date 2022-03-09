using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Kicking Move", menuName = "Moves/Kicking Move")]
public class KickingMoves : Moves
{


    public int ballLanded;
    public float recoveryChance;

    public override void Use()
    {
        base.Use();
    }


}
