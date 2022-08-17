using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public Sprite movePic = null;

    [Header("Unlock Value")]
    public int unlockValue;

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

    [Header("For Buff System")]
    public int baseFatigue;
    public float baseSuccess;
    public float baseCrit;

    [Header("Dialogue")]
    public DialogueClass[] MainCommentatorDialogue;
    public DialogueClass[] ColourCommentatorDialogue;

    public virtual void Use()
    {

    }
    
    public virtual void Turnover(string user)
    {
        GameManager.instance.Turnover(user);
    }

    public virtual void Foul(string user)
    {
        GameManager.instance.Foul(user);
    }

    public virtual void Recover(string user)
    {
        if (user == "Player")
        {
            GameManager.instance.ChangePhase("Attack Phase");
        }

        if (user == "Enemy")
        {
            GameManager.instance.ChangePhase("Defence Phase");
        }
    }
}
