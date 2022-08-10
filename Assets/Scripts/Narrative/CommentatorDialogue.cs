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

    public IEnumerator IntroComms()
    {
        if(mc_anim.GetBool("Start") != true)
        {
            mc_anim.SetBool("Start", true);
        }

        yield return new WaitForSeconds(1.5f);

        if (introDialogue.Length == index)
        {
            Debug.Log(index);
            Debug.Log(introDialogue.Length);
            mc_anim.SetBool("End", true);
            cc_anim.SetBool("End", true);
            StopCoroutine(IntroComms());
        }

        dialogue.StartDialogue(introDialogue[index]);

        index += 1;

        yield return new WaitWhile(() => dialogue.typing);

        StartCoroutine(ContinueIntro());
    }

    public IEnumerator ContinueIntro()
    {
        if(cc_anim.GetBool("Start") != true)
        {
            cc_anim.SetBool("Start", true);
        }

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(IntroComms());
    }

    public void MoveDialogue(Moves thisMove)
    {
        if(thisMove.phase == "Coin Toss")
        {
            StartCoroutine(SetDialogue(thisMove.MainCommentatorDialogue[0], thisMove.ColourCommentatorDialogue[0]));
            return;
        }

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
        mc_anim.SetBool("Start", true);
        dialogue.StartDialogue(mcDialogue);

        yield return new WaitForSeconds(1.5f);

        cc_anim.SetBool("Start", true);
        dialogue.StartDialogue(ccDialogue);

        yield return new WaitForSeconds(2f);

        mc_anim.SetBool("End", true);
        cc_anim.SetBool("End", true);
    }
}
