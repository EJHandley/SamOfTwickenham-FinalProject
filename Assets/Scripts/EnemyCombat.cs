using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {

    }

    #region Kicks
    public void UseKickOne()
    {
        int recoveryCheck = Random.Range(1, 101);

        //This will come from the move
        int recoveryChance = 10;

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(25, 41);
        gameManager.resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        if (recoveryCheck < recoveryChance)
        {
            Debug.Log("OPPONENT RECOVERED THE BALL!");
            gameManager.DefencePhase();
            return;
        }
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.AttackPhase();
        }
    }

    public void UseKickTwo()
    {
        int recoveryCheck = Random.Range(1, 101);

        //This will come from the move
        int recoveryChance = 40;

        int meters = gameManager.resourceBars.startingMeters -= Random.Range(10, 16);
        gameManager.resourceBars.ChangeMeters(meters);

        if (recoveryCheck < recoveryChance)
        {
            Debug.Log("OPPONENT RECOVERED THE BALL!");
            gameManager.DefencePhase();
            return;
        }
        else if (recoveryCheck > recoveryChance)
        {
            gameManager.AttackPhase();
        }
    }

    public void KickReturn()
    {

    }
    #endregion

    #region Attacks
    public void UseAttackOne()
    {

    }

    public void UseAttackTwo()
    {

    }

    public void UseAttackThree()
    {

    }

    public void UseAttackFour()
    {

    }

    public void UseAttackFive()
    {

    }

    public void UseAttackSix()
    {

    }
    #endregion

    #region Defence
    public void UseDefenceOne()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceTwo()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceThree()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceFour()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceFive()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }

    public void UseDefenceSix()
    {
        Debug.Log("THE OPPOSITION IS DEFENDING HARD");
    }
    #endregion

}
