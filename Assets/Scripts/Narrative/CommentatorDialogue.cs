using System.Collections;
using UnityEngine;
using TMPro;

public class CommentatorDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueClass[] introDialogue;

    [Header("Animations")]
    public Animator mc_anim;
    public Animator cc_anim;

    public bool wait = false;
    public int index = 0;

    void Start()
    {
        StartIntro();
    }


    void Update()
    {

    }

    public void StartIntro()
    {
        StartCoroutine(IntroComms());
    }

    public void ResetAnims()
    {
        mc_anim.SetTrigger("Default");
        cc_anim.SetTrigger("Default");
        dialogue.typing = false;
    }

    public IEnumerator IntroComms()
    {
        mc_anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        if (introDialogue.Length == index)
        {
            Debug.Log("Narrative Ended");
            mc_anim.SetTrigger("End");
            cc_anim.SetTrigger("End");
            StopCoroutine(IntroComms());
        }

        dialogue.StartDialogue(introDialogue[index]);

        index += 1;

        yield return new WaitWhile(() => dialogue.typing);

        StartCoroutine(ContinueIntro());
    }

    public IEnumerator ContinueIntro()
    {
        cc_anim.SetTrigger("Start");

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(IntroComms());
    }

    public void MoveDialogue(Moves thisMove)
    {
        StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[0], thisMove.ColourCommentatorDialogue[0]));
    }

    private IEnumerator SetDialogue(DialogueClass mcDialogue, DialogueClass ccDialogue)
    {
        ResetAnims();

        yield return new WaitForSeconds(0.2f);

        mc_anim.SetTrigger("Start");
        dialogue.StartDialogue(mcDialogue);

        yield return new WaitWhile(() => dialogue.typing);

        cc_anim.SetTrigger("Start");
        dialogue.StartDialogue(ccDialogue);

        yield return new WaitWhile(() => dialogue.typing);

        mc_anim.SetTrigger("End");
        cc_anim.SetTrigger("End");
    }

    private void HeldCode(Moves thisMove)
    {
        //code for multiple option dialogue system

        int commChoice = Random.Range(1, 4);
        if (commChoice == 1)
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[0], thisMove.ColourCommentatorDialogue[0]));
        }
        else if (commChoice == 2)
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[1], thisMove.ColourCommentatorDialogue[1]));
        }
        else if (commChoice == 3)
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[2], thisMove.ColourCommentatorDialogue[2]));
        }
    }
}
