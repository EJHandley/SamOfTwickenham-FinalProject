using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;

    public bool BasicType;
    public bool StarType;
    public bool TeamType;
    public bool SpecialType;

    public int fatigueCost;

    public virtual void Use()
    {

    }
        
}
