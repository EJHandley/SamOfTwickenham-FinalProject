using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public Sprite movePic = null;

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

    [Header("Commentator Dialogue")]
    [Header("Comm Choice 1")]
    [TextArea(3, 10)] public string MCDialogue1;
    [TextArea(3, 10)] public string CCDialogue1;
    [Header("Comm Choice 2")]
    [TextArea(3, 10)] public string MCDialogue2;
    [TextArea(3, 10)] public string CCDialogue2;
    [Header("Comm Choice 3")]
    [TextArea(3, 10)] public string MCDialogue3;
    [TextArea(3, 10)] public string CCDialogue3;

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
