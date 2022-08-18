using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public Button skillsButton;
    public Button setPieceButton;
    public Button scrimmageButton;

    public GameObject skillsInfo;
    public GameObject setPieceInfo;
    public GameObject scrimmageInfo;

    public GameObject skillsRewards;
    public GameObject setPieceRewards;
    public GameObject scrimmageRewards;

    private int egoBuff;
    private int tmBuff;

    public static bool trainingChosen = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(skillsButton != null && setPieceButton != null && scrimmageButton != null)
        {
            if(trainingChosen == true)
            {
                skillsButton.interactable = false;
                setPieceButton.interactable = false;
                scrimmageButton.interactable = false;
            }
        }
    }

    public void ChooseSkills()
    {
        egoBuff = 10;
        tmBuff = 5;
        playerStats.egoValue += egoBuff;
        playerStats.teamValue -= tmBuff;

        skillsInfo.SetActive(false);
        skillsRewards.SetActive(true);
        trainingChosen = true;

        LevelManager.instance.SetStats();
    }

    public void ChooseSetPiece()
    {
        egoBuff = 5;
        tmBuff = 5;
        playerStats.egoValue += egoBuff;
        playerStats.teamValue += tmBuff;

        setPieceInfo.SetActive(false);
        setPieceRewards.SetActive(true);
        trainingChosen = true;

        LevelManager.instance.SetStats();
    }

    public void ChooseScrimmage()
    {
        egoBuff = 5;
        tmBuff = 10;
        playerStats.egoValue -= egoBuff;
        playerStats.teamValue += tmBuff;

        scrimmageInfo.SetActive(false);
        scrimmageRewards.SetActive(true);
        trainingChosen = true;

        LevelManager.instance.SetStats();
    }
}
