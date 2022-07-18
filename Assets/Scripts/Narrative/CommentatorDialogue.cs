using System.Collections;
using UnityEngine;
using TMPro;

public class CommentatorDialogue : MonoBehaviour
{
    public DialogueClass[] introDialogue;

    void Start()
    {

    }


    void Update()
    {

    }

    public void StartIntro()
    {
        StartCoroutine(MCIntroComms());
    }

    public IEnumerator MCIntroComms()
    {
        int index = 0;

        GameManager.instance.dialogueManager.StartDialogue(introDialogue[index]);

        index += 2;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(CCIntroComms());
    }

    public IEnumerator CCIntroComms()
    {
        int index = 1;

        GameManager.instance.dialogueManager.StartDialogue(introDialogue[index]);

        index += 2;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(MCIntroComms());
    }

    public void MoveDialogue(Moves thisMove)
    {
        int commChoice = Random.Range(1, 4);
        if(commChoice == 1)
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[0], thisMove.ColourCommentatorDialogue[0]));
        }
        else if(commChoice == 2)
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[1], thisMove.ColourCommentatorDialogue[1]));
        }
        else if(commChoice == 3)
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[2], thisMove.ColourCommentatorDialogue[2]));
        }
    }

    private IEnumerator SetDialogue(DialogueClass mcDialogue, DialogueClass ccDialogue)
    {
        GameManager.instance.dialogueManager.StartDialogue(mcDialogue);

        yield return new WaitForSeconds(1.5f);

        GameManager.instance.dialogueManager.StartDialogue(ccDialogue);
    }
}
