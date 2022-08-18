using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using Ink.Runtime;
using TMPro;

public class ConferenceDialogue : MonoBehaviour
{
    #region Singleton
    private static ConferenceDialogue instance;
    void Awake()
    {
        if (instance != null)
            Debug.Log("More than one instance of this in the scene");

        instance = this;
    }
    #endregion

    private Story story;
    private TextAsset thisStory;

    public TextAsset winDialogue;
    public TextAsset lossDialogue;

    public static bool gameWon;

    [SerializeField] private Dialogue dialogue;

    [Header("Player Stats Ref")]
    [SerializeField] private PlayerStats playerStats;

    [Header("Dialogue UI")]
    [SerializeField] private TMP_Text dialogueText = null;
    [SerializeField] private TMP_Text npcDialogueText = null;
    [SerializeField] private TMP_Text npcNameText = null;

    [Header("Choice UI")]
    [SerializeField] private TMP_Text[] choicesText;

    [Header("End of Story UI")]
    [SerializeField] private GameObject endOfStoryScreen;
    [SerializeField] private TMP_Text egoText;
    [SerializeField] private TMP_Text tmText;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void SetWinStory(TextAsset story)
    {
        winDialogue = story;
    }

    public void SetLossStory(TextAsset story)
    {
        lossDialogue = story;
        SetStory();
    }

    public void SetStory()
    {
        if (gameWon)
        {
            thisStory = winDialogue;
        }
        else if (!gameWon)
        {
            thisStory = lossDialogue;

        }

        story = new Story(thisStory.text);
        ContinueStory();
    }    

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            string currentDialogue = story.Continue();

            if (story.currentTags.Count > 0)
            {
                string name = story.currentTags[0] + ":";
                string npcDialogue = currentDialogue;

                SetNPCDialogue(npcDialogue, name);
            }
            else
            {
                string playerDialogue = currentDialogue;
                SetPlayerDialogue(playerDialogue);
            }

            if (story.currentChoices != null)
                PopulateChoices();
        }
        else if (!story.canContinue)
        {
            EndOfStory();
            return;
        }
    }

    public void SetPlayerDialogue(string currentDialogue)
    {
        StartCoroutine(dialogue.TypeSentence(currentDialogue, dialogueText, "Player"));
        ContinueStory();
    }

    public void SetNPCDialogue(string currentDialogue, string npcName)
    {
        StartCoroutine(dialogue.TypeSentence(npcName, npcNameText, "NPC"));
        StartCoroutine(dialogue.TypeSentence(currentDialogue, npcDialogueText, "NPC"));
    }

    private void PopulateChoices()
    {
        int index = 0;

        foreach (Choice choice in story.currentChoices)
        {
            choicesText[index].text = choice.text;
            index++;
        }
    }

    public void InputChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);

        foreach (TMP_Text choice in choicesText)
            choice.text = "";

        ContinueStory();
    }

    public void AddBuffs()
    {
        string egoStat = story.variablesState["Ego"].ToString();
        string tmStat = story.variablesState["TeamMorale"].ToString();

        int egoVal = int.Parse(egoStat);
        int tmVal = int.Parse(tmStat);

        playerStats.egoValue += egoVal;
        playerStats.teamValue += tmVal;
    }

    public void EndOfStory()
    {
        AddBuffs();
        egoText.text = "Your Ego increased to: " + playerStats.egoValue.ToString();
        tmText.text = "Your Team Morale increased to: " + playerStats.teamValue.ToString();
    }
}
