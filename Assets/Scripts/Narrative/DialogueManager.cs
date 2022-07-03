using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    private static DialogueManager instance;
	void Awake()
	{
		if (instance != null)
			Debug.Log("More than one instance of this in the scene");

		instance = this;
	}
    #endregion

    public static event Action<Story> OnCreateStory;

	[SerializeField] private TextAsset inkJSONAsset = null;
	private Story story;

    [Header("Dialogue UI")]
	[SerializeField] private TMP_Text dialogueText = null;
    [SerializeField] private TMP_Text npcDialogueText = null;
    [SerializeField] private TMP_Text npcNameText = null;

    [Header("Choice UI")]
    [SerializeField] private Button[] choiceButtons;
    [SerializeField] private TMP_Text[] choicesText;

    private void Start()
    {
        story = new Story(inkJSONAsset.text);

        ContinueStory();
    }

    private void Update()
    {
        
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
    }

    public void SetPlayerDialogue(string currentDialogue)
    {
        dialogueText.text = currentDialogue;
        ContinueStory();
    }

    public void SetNPCDialogue(string currentDialogue, string npcName)
    {
        npcNameText.text = npcName;
        npcDialogueText.text = currentDialogue;
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

    }

}
