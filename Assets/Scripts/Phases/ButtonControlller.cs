using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControlller : MonoBehaviour
{
    private MoveController moveController;

    private Tooltip tooltip;
    private Image image;
    private TMP_Text text;

    public Moves thisMove;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = thisMove.icon;

        text = GetComponentInChildren<TMP_Text>();
        text.text = thisMove.name;

        tooltip = GetComponentInChildren<Tooltip>(true);
        tooltip.SetTooltip(thisMove);
    }

    void Update()
    {
        
    }

    public void OnPress()
    {
        moveController.UseMove(thisMove);
    }
}
