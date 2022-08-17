using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceBars : MonoBehaviour
{
    public Slider meterFill;
    public Slider fatigueFill;

    public int startingMeters;
    public int startingFatigue;

    public TMP_Text indicator;

    void Start()
    {
        startingMeters = 50;
        startingFatigue = 100;
    }

    void Update()
    {

    }

    public void ChangeMeters(string user, int addMeters)
    {
        if(user == "Player")
        {
            int currentMeters;
            currentMeters = Mathf.Clamp(startingMeters += addMeters, 0, 100);

            meterFill.value = currentMeters;
            indicator.text = meterFill.value.ToString();
        } 
        else if(user == "Enemy")
        {
            int currentMeters;
            currentMeters = Mathf.Clamp(startingMeters -= addMeters, 0, 100);

            meterFill.value = currentMeters;
            indicator.text = meterFill.value.ToString();
        }


        if (meterFill.value >= 100)
        {
            startingMeters = 50;
            meterFill.value = startingMeters;
            GameManager.instance.PlayerScores();
            GameManager.instance.ChangePhase("Kick Return");
            return;
        }
        else if (meterFill.value <= 0)
        {
            startingMeters = 50;
            meterFill.value = startingMeters;
            GameManager.instance.OppoScores();
            GameManager.instance.ChangePhase("Kicking Phase");
            return;
        }
    }

    public void ChangeFatigue(string user, int minusFatigue)
    {
        if(user == "Player")
        {
            int currentFatigue;
            currentFatigue = Mathf.Clamp(startingFatigue -= minusFatigue, 0, 100);

            fatigueFill.value = currentFatigue;

            if(currentFatigue == 0)
            {
                GameManager.instance.Turnover(user);
            }
        }
        else if(user == "Enemy")
        {
            int currentFatigue;
            currentFatigue = Mathf.Clamp(startingFatigue += minusFatigue, 0, 100);

            fatigueFill.value = currentFatigue;
        }
    }
}
