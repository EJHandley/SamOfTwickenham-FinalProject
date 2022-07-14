using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommentatorDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;

    public TMP_Text MCText;
    public TMP_Text CCText;

    void Start()
    {

    }


    void Update()
    {

    }

    public IEnumerator IntroComms()
    {

        yield return new WaitForSeconds(0.5f);
    }

    public void MoveDialogue(Moves thisMove)
    {
        int commChoice = Random.Range(1, 4);
        if(commChoice == 1)
        {

        }
        else if(commChoice == 2)
        {

        }
        else if(commChoice == 3)
        {
            SetMCDialogue(thisMove.MCDialogue[2]);
            SetCCDialogue(thisMove.CCDialogue[2]);
        }

    }

    private void SetMCDialogue(DialogueClass dialogue)
    {
        dialogueManager.StartDialogue(dialogue);
    }

    private void SetCCDialogue(DialogueClass dialogue)
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
