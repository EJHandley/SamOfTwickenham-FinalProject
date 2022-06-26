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
	[SerializeField] private TMP_Text playerText = null;
    [SerializeField] private TMP_Text playerName = null;
    [SerializeField] private TMP_Text npcText = null;
    [SerializeField] private TMP_Text npcName = null;

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
        string text = "";

        if(story.canContinue)
        {
            text = story.ContinueMaximally();

            if (story.currentChoices != null)
                PopulateChoices();

            List<string> tags = story.currentTags;

            if(tags.Count > 0)
            {
                if (tags[0] == "The Gaffer")
                {
                    npcName.text = tags[0];
                    SetNPCDialogue(text);
                }

                if (tags[1] == "Sam")
                {
                    playerName.text = tags[1];
                    SetPlayerDialogue(text);
                }
            }
        }
    }

    public void SetPlayerDialogue(string dialogue)
    {
        playerText.text = dialogue;
    }

    public void SetNPCDialogue(string dialogue)
    {
        npcText.text = dialogue;
    }

    private void PopulateChoices()
    {
        int index = 0;

        foreach (Choice choice in story.currentChoices)
        {
            Debug.Log(choice.index);

            choicesText[index].text = choice.text;
            index++;
        }
    }

    public void InputChoice(int choice)
    {
        story.ChooseChoiceIndex(choice);
        ContinueStory();
    }

}
