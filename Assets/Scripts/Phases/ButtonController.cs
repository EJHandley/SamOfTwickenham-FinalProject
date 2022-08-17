using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public PlayerStats playerStats;
    private MoveController moveController;

    private Tooltip tooltip;
    private Image[] images;
    private TMP_Text text;
    public Button thisButton;

    [Header("Move Selector Variables")]
    public int buttonNumber;
    public bool isAttack;
    public bool isDefence;

    public Moves thisMove;

    void Start()
    {
        moveController = GetComponentInParent<MoveController>();
        thisButton = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
        images = GetComponentsInChildren<Image>();
        tooltip = GetComponentInChildren<Tooltip>(true);

        if (thisMove == null)
        {
            if (MoveSelector.attackMoves.Count == 0 || MoveSelector.defenceMoves.Count == 0)
                return;

            if (isAttack)
            {
                thisMove = MoveSelector.attackMoves[buttonNumber];
            }
            else if (isDefence)
            {
                thisMove = MoveSelector.defenceMoves[buttonNumber];
            }
        }

        if(thisMove.type == "Star")
        {
            if(playerStats.egoValue >= thisMove.unlockValue)
            {
                thisButton.interactable = true;
            }
        }

        if(thisMove.type == "Team")
        {
            if(playerStats.teamValue >= thisMove.unlockValue)
            {
                thisButton.interactable = true;
            }
        }

        images[1].sprite = thisMove.icon;

        if(thisButton.interactable == false)
        {
            Debug.Log("Change Colour");
            images[1].color = new Color(100, 100, 100, 255);
        }    

        text.text = thisMove.name;

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
        StartCoroutine(UseMove());
    }

    private IEnumerator UseMove()
    {


        if (thisMove.movePic != null)
        {
            StartCoroutine(GameManager.instance.SplashUI(thisMove));

            yield return new WaitForSeconds(4f);
        }

        if (thisMove.phase == "Coin Toss")
        {
            moveController.UseCoinTossMove((CoinTossMoves)thisMove);
        }

        if (thisMove.phase == "Attack Phase")
        {
            moveController.UseAttackMove((AttackMoves)thisMove);
        }

        if (thisMove.phase == "Defence Phase")
        {
            moveController.UseDefenceMove((DefenceMoves)thisMove);
        }

        if (thisMove.phase == "Kick Phase")
        {
            moveController.UseKickMove((KickingMoves)thisMove);
        }

        yield return new WaitForSeconds(2f);
    }

    private void HoldVoid()
    {
        GameManager.instance.commentatorDialogue.MoveDialogue(thisMove);
        GameManager.instance.commentatorDialogue.MoveDialogue(thisMove);

        if (thisMove.movePic != null)
        {
            StartCoroutine(GameManager.instance.SplashUI(thisMove));
        }

        if (thisMove.phase == "Coin Toss")
        {
            moveController.UseCoinTossMove((CoinTossMoves)thisMove);
        }

        if (thisMove.phase == "Attack Phase")
        {
            moveController.UseAttackMove((AttackMoves)thisMove);
        }

        if (thisMove.phase == "Defence Phase")
        {
            moveController.UseDefenceMove((DefenceMoves)thisMove);
        }

        if (thisMove.phase == "Kick Phase")
        {
            moveController.UseKickMove((KickingMoves)thisMove);
        }
    }
}
