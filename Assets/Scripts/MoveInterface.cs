using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInterface : MonoBehaviour
{
    public ResourceBars resourceBars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseMoveOne()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 40;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(15, 21);
        resourceBars.ChangeMeters(meters);
        Debug.Log(meters);

        int fatigue = resourceBars.startingFatigue += 10;
        resourceBars.ChangeFatigue(fatigue);
        Debug.Log(fatigue);
    }

    public void UseMoveTwo()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 75;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(40, 61);
        resourceBars.ChangeMeters(meters);

        int fatigue = resourceBars.startingFatigue += 30;
        resourceBars.ChangeFatigue(fatigue);
    }

    public void UseMoveThree()
    {
        int turnoverCheck = Random.Range(1, 101);

        //This will come from the move
        int turnoverChance = 10;

        if (turnoverCheck < turnoverChance)
        {
            Debug.Log("TURNOVER");
            return;
        }

        int meters = resourceBars.startingMeters += Random.Range(5, 11);
        resourceBars.ChangeMeters(meters);

        int fatigue = resourceBars.startingFatigue += 5;
        resourceBars.ChangeFatigue(fatigue);
    }
}
