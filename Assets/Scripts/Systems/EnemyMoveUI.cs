using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyMoveUI : MonoBehaviour
{
    public Moves setMove;

    private Image[] images;
    private TMP_Text text;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        
    }

    public void UpdateUI()
    {
        images = this.GetComponentsInChildren<Image>();
        images[1].sprite = setMove.icon;

        text = this.GetComponentInChildren<TMP_Text>();
        text.text = setMove.name;
    }
}
