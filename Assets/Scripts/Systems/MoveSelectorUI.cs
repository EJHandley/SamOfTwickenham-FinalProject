using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveSelectorUI : MonoBehaviour
{
    public Stat playerStats;
    public int unlockValue;
    private Button thisButton;

    private Image[] images;
    private TMP_Text text;

    [Header("Move Selector Variables")]
    public int buttonNumber;
    public bool isAttack;
    public bool isDefence;
    [SerializeField] private Moves setMove;

    void Start()
    {
        thisButton = this.GetComponent<Button>();
    }

    void FixedUpdate()
    {
        if (isAttack && MoveSelector.attackMoves.Count < buttonNumber + 1 || isDefence && MoveSelector.defenceMoves.Count < buttonNumber + 1)
        {
            ClearUI();
            return;
        }

        if (isAttack)
        {
            setMove = MoveSelector.attackMoves[buttonNumber];
            UpdateUI();
        }
        else if (isDefence)
        {
            setMove = MoveSelector.defenceMoves[buttonNumber];
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        Debug.Log("TEST");

        images = this.GetComponentsInChildren<Image>();
        images[1].sprite = setMove.icon;

        text = this.GetComponentInChildren<TMP_Text>();
        text.text = setMove.name;
    }

    public void ClearUI()
    {
        images = this.GetComponentsInChildren<Image>();
        images[1].sprite = null;

        text = this.GetComponentInChildren<TMP_Text>();
        text.text = "";
    }
}
