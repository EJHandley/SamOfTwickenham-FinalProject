using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public GameObject tooltip;

    public void ShowTooltip()
    {
        Debug.Log("Hovering");
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        Debug.Log("Not Hovering");
        tooltip.SetActive(false);
    }
}
