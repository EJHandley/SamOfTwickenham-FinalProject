using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;

    [Header("Move Type")]
    public bool Normal;
    public bool Star;
    public bool Team;
    public bool SetPiece;

    [Header("Move Style")]
    public bool Ground;
    public bool Kick;
    public bool Special;

    [Header("Move Stats")]
    public int fatigueCost;
    public float successChance;
    public float criticalSuccess;

    public virtual void Use()
    {

    }
        
}
