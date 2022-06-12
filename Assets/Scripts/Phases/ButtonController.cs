using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    private MoveController moveController;

    private Tooltip tooltip;
    private Image image;
    private TMP_Text text;

    public Moves thisMove;

    void Start()
    {
        moveController = GetComponentInParent<MoveController>();

        image = GetComponent<Image>();
        image.sprite = thisMove.icon;

        text = GetComponentInChildren<TMP_Text>();
        text.text = thisMove.name;

        tooltip = GetComponentInChildren<Tooltip>(true);

        if(thisMove.phase == "Attack Phase")
        {
            tooltip.SetAttackTooltip((AttackMoves)thisMove);
        }    

        if(thisMove.phase == "Defence Phase")
        {
            tooltip.SetDefenceTooltip((DefenceMoves)thisMove);
        }

        if(thisMove.phase == "Kick Phase")
        {
            tooltip.SetKickTooltop((KickingMoves)thisMove);
        }
    }

    void Update()
    {
        
    }

    public void OnPress()
    {
        if(thisMove.phase == "Attack Phase")
        {
            moveController.UseAttackMove((AttackMoves)thisMove);
        }

        if(thisMove.phase == "Defence Phase")
        {
            moveController.UseDefenceMove((DefenceMoves)thisMove);
        }

        if(thisMove.phase == "Kick Phase")
        {
            moveController.UseKickMove((KickingMoves)thisMove);
        }
    }
}