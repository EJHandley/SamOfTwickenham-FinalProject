using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveSelectorTooltip : MonoBehaviour
{
    private Transform tooltip;

    private TMP_Text[] tooltipText;
    private TMP_Text titleText;
    private TMP_Text moveTypeText;
    private TMP_Text fatigueCostText;
    private TMP_Text successChanceText;
    private TMP_Text meterChangeText;
    private TMP_Text critChanceText;
    private TMP_Text critMetersText;
    private TMP_Text timeCostText;
    private TMP_Text unlockValueText;

    private TMP_Text buffedSuccessText;
    private TMP_Text buffedFatigueText;
    private TMP_Text buffedMeterText;
    private TMP_Text buffedCritText;
    private TMP_Text buffedCritMeterText;

    public GameObject buffSuccess;
    public GameObject buffFatigue;
    public GameObject buffMeter;
    public GameObject buffCrit;
    public GameObject buffCritMeters;

    private string unlockStat;

    private void Start()
    {
        tooltip = transform.GetChild(0);

        //Assign the correct object index to each text entry for the Tooltip
        tooltipText = GetComponentsInChildren<TMP_Text>(true);

        titleText = tooltipText[6];
        moveTypeText = tooltipText[7];


        fatigueCostText = tooltipText[0];
        successChanceText = tooltipText[1];
        meterChangeText = tooltipText[2];
        critChanceText = tooltipText[3];
        critMetersText = tooltipText[4];
        timeCostText = tooltipText[5];
        unlockValueText = tooltipText[14];

        buffedFatigueText = tooltipText[15];
        buffedSuccessText = tooltipText[16];
        buffedMeterText = tooltipText[17];
        buffedCritText = tooltipText[18];
        buffedCritMeterText = tooltipText[19];
    }

    public void ShowTooltip()
    {
        tooltip.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.gameObject.SetActive(false);
    }

    public void SetAttackTooltip(AttackMoves thisMove)
    {
        if(thisMove.type != "Normal")
        {
            if (thisMove.type == "Star")
            {
                unlockStat = "Ego";
            }
            else if (thisMove.type == "Team")
            {
                unlockStat = "Team Morale";
            }

            unlockValueText.text = "Unlocked at - " + unlockStat + ": " + thisMove.unlockValue.ToString();

            if (thisMove.successChance > thisMove.baseSuccess)
            {
                buffSuccess.SetActive(true);
                buffFatigue.SetActive(true);
                buffMeter.SetActive(true);
                buffCrit.SetActive(true);
                buffCritMeters.SetActive(true);

                buffedSuccessText.text = "=>    " + thisMove.successChance.ToString() + "%";
                buffedFatigueText.text = "=>    " +thisMove.fatigueCost.ToString();
                buffedMeterText.text = "=>    " + thisMove.minMeterGain.ToString() + " - " + thisMove.maxMeterGain.ToString();
                buffedCritText.text = "=>    " + thisMove.criticalSuccess.ToString() + "%";
                buffedCritMeterText.text = "=>    " + thisMove.critMinMeterGain.ToString() + " - " + thisMove.critMaxMeterGain.ToString();
            }
        }

        titleText.text = thisMove.name;
        moveTypeText.text = thisMove.type + " (" + thisMove.style + ")";
        successChanceText.text = thisMove.baseSuccess.ToString() + "%";
        fatigueCostText.text = thisMove.baseFatigue.ToString();
        meterChangeText.text = thisMove.baseMinGain.ToString() + " - " + thisMove.baseMaxGain.ToString();
        critChanceText.text = thisMove.baseCrit.ToString() + "%";
        critMetersText.text = thisMove.baseCritMin.ToString() + " - " + thisMove.baseCritMax.ToString();

        float minutes = Mathf.FloorToInt(thisMove.timeCost / 60);
        float seconds = Mathf.FloorToInt(thisMove.timeCost % 60);
        timeCostText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    public void SetDefenceTooltip(DefenceMoves thisMove)
    {
        if(thisMove.type != "Normal")
        {
            if (thisMove.type == "Star")
            {
                unlockStat = "Ego";
            }
            else if (thisMove.type == "Team")
            {
                unlockStat = "Team Morale";
            }

            unlockValueText.text = "Unlocked at - " + unlockStat + ": " + thisMove.unlockValue.ToString();

            if(thisMove.successChance > thisMove.baseSuccess)
            {
                buffSuccess.SetActive(true);
                buffFatigue.SetActive(true);
                buffMeter.SetActive(true);
                buffCrit.SetActive(true);
                buffCritMeters.SetActive(true);

                buffedSuccessText.text = "=>    " + thisMove.successChance.ToString() + "%";
                buffedFatigueText.text = "=>    " + thisMove.fatigueCost.ToString();
                buffedMeterText.text = "=>    " + thisMove.minMeterStop.ToString() + " - " + thisMove.maxMeterStop.ToString();
                buffedCritText.text = "=>    " + thisMove.criticalSuccess.ToString() + "%";
                buffedCritMeterText.text = "=>    " + thisMove.critMinMeterStop.ToString() + " - " + thisMove.critMaxMeterStop.ToString();
            }
        }

        titleText.text = thisMove.name;
        moveTypeText.text = thisMove.type + " (" + thisMove.style + ")";
        successChanceText.text = thisMove.baseSuccess.ToString() + "%";
        fatigueCostText.text = thisMove.baseFatigue.ToString();
        meterChangeText.text = thisMove.baseMinStop.ToString() + " - " + thisMove.baseMaxStop.ToString();
        critChanceText.text = thisMove.baseCrit.ToString() + "%";
        critMetersText.text = thisMove.baseCritMin.ToString() + " - " + thisMove.baseCritMax.ToString();
    }
}
