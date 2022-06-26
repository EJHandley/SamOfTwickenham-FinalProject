using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private Transform tooltip;

    private TMP_Text[] tooltipText;
    private TMP_Text titleText;
    private TMP_Text moveTypeText;
    private TMP_Text successChanceText;
    private TMP_Text fatigueCostText;
    private TMP_Text meterChangeText;
    private TMP_Text timeCostText;

    private void Start()
    {
        tooltip = transform.GetChild(0);

        //Assign the correct object index to each text entry for the Tooltip
        tooltipText = GetComponentsInChildren<TMP_Text>(true);

        titleText = tooltipText[0];
        moveTypeText = tooltipText[1];
        successChanceText = tooltipText[2];
        fatigueCostText = tooltipText[3];
        meterChangeText = tooltipText[4];
        timeCostText = tooltipText[5];
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
        titleText.text = thisMove.name;
        moveTypeText.text = thisMove.type + " (" + thisMove.style + ")";
        successChanceText.text = "Success Chance: " + thisMove.successChance.ToString() + "%";
        fatigueCostText.text = "Fatigue Cost: " + thisMove.fatigueCost.ToString();
        meterChangeText.text = "Meter Change: " + thisMove.minMeterGain.ToString() + " - " + thisMove.maxMeterGain.ToString();

        float minutes = Mathf.FloorToInt(thisMove.timeCost / 60);
        float seconds = Mathf.FloorToInt(thisMove.timeCost % 60);
        timeCostText.text = "Time Cost: " + string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    public void SetDefenceTooltip(DefenceMoves thisMove)
    {
        titleText.text = thisMove.name;
        moveTypeText.text = thisMove.type + " (" + thisMove.style + ")";
        successChanceText.text = "Success Chance: " + thisMove.successChance.ToString() + "%";
        fatigueCostText.text = "Fatigue Cost: " + thisMove.fatigueCost.ToString();
        meterChangeText.text = "Meter Change: " + thisMove.minMeterStop.ToString() + " - " + thisMove.maxMeterStop.ToString();
    }

    public void SetKickTooltop(KickingMoves thisMove)
    {
        titleText.text = thisMove.name;
        moveTypeText.text = thisMove.type + " (" + thisMove.style + ")";
        successChanceText.text = "Success Chance: " + thisMove.successChance.ToString() + "%";
        fatigueCostText.text = "Fatigue Cost: " + thisMove.fatigueCost.ToString();
        meterChangeText.text = "Meter Change: " + thisMove.minMeterGain.ToString() + " - " + thisMove.maxMeterGain.ToString();
        
        float minutes = Mathf.FloorToInt(thisMove.timeCost / 60);
        float seconds = Mathf.FloorToInt(thisMove.timeCost % 60);
        timeCostText.text = "Time Cost: " + string.Format("{00:00}:{01:00}", minutes, seconds);
    }
}
