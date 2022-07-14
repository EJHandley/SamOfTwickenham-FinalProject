using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueClass dialogue)
    {
        nameText.text = dialogue.charName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplaySentence();
    }

    public void DisplaySentence()
    {
        dialogueText.text = " ";

        if (sentences.Count == 0)
            return;

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(0.5f);

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
