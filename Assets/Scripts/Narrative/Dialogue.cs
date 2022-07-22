using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private Queue<string> sentences;

    public TMP_Text mcText;
    public TMP_Text ccText;

    public bool typing;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueClass dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if(dialogue.charName == "MC")
        {
            DisplaySentence(mcText);
        }
        
        if(dialogue.charName == "CC")
        {
            DisplaySentence(ccText);
        }
    }

    public void DisplaySentence(TMP_Text text)
    {
        text.text = "";

        if (sentences.Count == 0)
            return;

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence, text));
    }

    public IEnumerator TypeSentence(string sentence, TMP_Text text)
    {
        yield return new WaitForSeconds(0.1f);

        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
