using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{
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
    
    public virtual void Turnover(string user)
    {
        if(user == "Player")
        {
            GameManager.instance.ChangePhase("Defence Phase");
        }

        if(user == "Enemy")
        {
            GameManager.instance.ChangePhase("Attack Phase");
        }
    }

    public virtual void Foul(string user)
    {
        Debug.Log("You Committed A Foul");
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
