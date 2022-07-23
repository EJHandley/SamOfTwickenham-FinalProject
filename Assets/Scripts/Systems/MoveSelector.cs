using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveSelector : MonoBehaviour
{
    #region Singleton
    public static MoveSelector instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    public static List<Moves> attackMoves = new List<Moves>();
    public static List<Moves> defenceMoves = new List<Moves>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void SelectAttackMove(Moves thisMove)
    {
        if (!attackMoves.Contains(thisMove))
        {
            Debug.Log("Adding " + thisMove);
            attackMoves.Add(thisMove);
            return;
        }

        if (attackMoves.Contains(thisMove))
        {
            Debug.Log("Removing " + thisMove);
            attackMoves.Remove(thisMove);
            return;
        }
    }

    public void SelectDefenceMove(Moves thisMove)
    {
        if(defenceMoves.Contains(thisMove))
        {
            defenceMoves.Remove(thisMove);
            return;
        }

        defenceMoves.Add(thisMove);
    }
}
