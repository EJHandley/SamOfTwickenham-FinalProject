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

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerScore = 0;
        currentOppoScore = 0;
    }

    // Update is called once per frame
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
}
