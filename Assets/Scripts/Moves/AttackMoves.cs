using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Move", menuName = "Moves/Attack Move")]
public class AttackMoves : Moves
{
    
    public int metersGained;
    public float turnoverChance;

    public override void Use()
    {
        base.Use();
    }

}
