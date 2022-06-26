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

    private float time = 0f;
    public TMP_Text timeText;

    private bool halfTimeTriggered = false;
    private bool fullTimeTriggered = false;

    void Start()
    {
        startingMeters = 50;
        startingFatigue = 100;

        SetTime(time);
    }

    void Update()
    {

    }

    public void SetTime(float currentTime)
    {
        if(time >= 2400f && halfTimeTriggered == false)
        {
            time = 2400f;
            GameManager.instance.HalfTime();
            halfTimeTriggered = true;
            return;
        }

        if(time >= 4800f && fullTimeTriggered == false)
        {
            time = 4800f;
            GameManager.instance.FullTime();
            fullTimeTriggered = true;
            return;
        }

        time += currentTime;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
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
        }
        else if(user == "Enemy")
        {
            int currentFatigue;
            currentFatigue = Mathf.Clamp(startingFatigue += minusFatigue, 0, 100);

            fatigueFill.value = currentFatigue;
        }
    }
}
