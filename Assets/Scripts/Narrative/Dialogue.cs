using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private Queue<string> sentences;

    public TMP_Text mcText;
    public TMP_Text ccText;

    public bool typing = false;

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
            DisplayNextSentence(mcText, "MC");
        }
        
        if(dialogue.charName == "CC")
        {
            DisplayNextSentence(ccText, "CC");
        }
    }

    public void DisplayNextSentence(TMP_Text text, string name)
    {
        typing = true;

        if (sentences.Count == 0)
        {
            typing = false;
            text.text = "";
            return;
        }

        text.text = "";

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence, text, name));
    }

    public IEnumerator TypeSentence(string sentence, TMP_Text text, string name)
    {
        yield return new WaitForSeconds(0.1f);

        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2f);

        if (name == "MC")
        {
            DisplayNextSentence(mcText, "MC");
        }

        if (name == "CC")
        {
            DisplayNextSentence(ccText, "CC");
        }
    }
}
