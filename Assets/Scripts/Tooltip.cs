using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private Transform tooltip;

    [Header("Tooltip Text Variables")]
    public TMP_Text[] tooltipText;
    private TMP_Text titleText;
    private TMP_Text moveTypeText;
    private TMP_Text successChanceText;
    private TMP_Text fatigueCostText;
    private TMP_Text meterChangeText;

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
    }

    public void ShowTooltip()
    {
        Debug.Log("Hovering");
        tooltip.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        Debug.Log("Not Hovering");
        tooltip.gameObject.SetActive(false);
    }

    public void SetTooltip(Moves thisMove)
    {
        titleText.text = thisMove.name;
        moveTypeText.text = thisMove.type + " (" + thisMove.style + ")";
        successChanceText.text = "Success Chance: " + thisMove.successChance.ToString() + "%";
        fatigueCostText.text = "Fatigue Cost: " + thisMove.fatigueCost.ToString();
    }
}
