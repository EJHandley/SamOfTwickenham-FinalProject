using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{
    private GameManager gameManager;

    new public string name = "New Item";
    public Sprite icon = null;

    [Header("Phase")]
    public string phase;

    [Header("Move Type")]
    public string type;

    [Header("Move Style")]
    public string style;

    [Header("Move Stats")]
    public int fatigueCost;
    public float successChance;
    public float criticalSuccess;

    public virtual void Use()
    {

    }
    
    public virtual void Turnover()
    {
        gameManager.ChangePhase("Defence Phase");
    }

    public virtual void Foul()
    {

    }
}
