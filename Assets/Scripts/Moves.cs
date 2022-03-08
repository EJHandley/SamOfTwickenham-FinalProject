using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;

    public bool isAttack;
    public bool isDefence;
    public bool isSpecial;

    public int fatigueCost;

    public virtual void Use()
    {

    }
        
}
