using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentPlayerScore;
    public int currentOppoScore;

    public TMP_Text playerScoreText;
    public TMP_Text oppoScoreText;

    public TMP_Text attackPhaseText;
    public GameObject attackUI;

    public TMP_Text defencePhaseText;
    public GameObject defenceUI;

    public TMP_Text kickingPhaseText;
    public GameObject kickingUI;

    void Start()
    {
        currentPlayerScore = 0;
        currentOppoScore = 0;
    }

    void Update()
    {
        playerScoreText.text = currentPlayerScore.ToString();
        oppoScoreText.text = currentOppoScore.ToString();
    }

    public void PlayerScores()
    {
        currentPlayerScore += 7;
    }

    public void OppoScores()
    {
        currentOppoScore += 7;
    }

    public void AttackPhase()
    {
        attackPhaseText.gameObject.SetActive(true);
        attackUI.SetActive(true);

        defencePhaseText.gameObject.SetActive(false);
        kickingPhaseText.gameObject.SetActive(false);

        defenceUI.SetActive(false);
        kickingUI.SetActive(false);
    }

    public void DefencePhase()
    {
        defencePhaseText.gameObject.SetActive(true);
        defenceUI.SetActive(true);

        attackPhaseText.gameObject.SetActive(false);
        kickingPhaseText.gameObject.SetActive(false);

        attackUI.SetActive(false);
        kickingUI.SetActive(false);
    }

    public void KickingPhase()
    {
        kickingPhaseText.gameObject.SetActive(true);
        kickingUI.SetActive(true);

        attackPhaseText.gameObject.SetActive(false);
        defencePhaseText.gameObject.SetActive(false);

        attackUI.SetActive(false);
        defenceUI.SetActive(false);
    }
}
