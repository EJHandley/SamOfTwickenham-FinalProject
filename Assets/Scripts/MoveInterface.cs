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
        int currentMeters = resourceBars.startingMeters += 10;
        resourceBars.ChangeMeters(currentMeters);

        int currentFatigue = resourceBars.startingFatigue += 5;
        resourceBars.ChangeFatigue(currentFatigue);
    }

    public void UseMoveTwo()
    {
        int currentMeters = resourceBars.startingMeters += 40;
        resourceBars.ChangeMeters(currentMeters);

        int currentFatigue = resourceBars.startingFatigue += 35;
        resourceBars.ChangeFatigue(currentFatigue);
    }
}
