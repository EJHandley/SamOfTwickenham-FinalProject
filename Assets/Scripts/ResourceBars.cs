using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBars : MonoBehaviour
{
    public GameManager gameManager;

    public Slider meterFill;
    public Slider fatigueFill;

    public int startingMeters;
    public int startingFatigue;

    void Start()
    {
        startingMeters = 50;
        startingFatigue = 0;
    }

    void Update()
    {

    }

    public void ChangeMeters(int currentMeters)
    {
        if(fatigueFill.value < 100)
        {
            currentMeters = Mathf.Clamp(currentMeters, 0, 100);
            meterFill.value = currentMeters;

            if (meterFill.value >= 100)
            {
                meterFill.value = 50;
                startingMeters = 50;
                gameManager.PlayerScores();
                gameManager.KickingPhase();
                return;
            }
            else if (meterFill.value <= 0)
            {
                meterFill.value = 50;
                startingMeters = 50;
                gameManager.OppoScores();
                gameManager.KickingPhase();
                return;
            }
        }
    }

    public void ChangeFatigue(int currentFatigue)
    {
        currentFatigue = Mathf.Clamp(currentFatigue, 0, 100);
        fatigueFill.value = currentFatigue;
    }
}
