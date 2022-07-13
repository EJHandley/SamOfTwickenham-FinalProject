using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommentatorDialogue : MonoBehaviour
{
    public TMP_Text MCText;
    public TMP_Text CCText;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void MoveDialogue(Moves thisMove)
    {
        int commChoice = Random.Range(1, 4);
        if(commChoice == 1)
        {
            SetMCDialogue(thisMove.MCDialogue1);
            SetCCDialogue(thisMove.CCDialogue1);
        }
        else if(commChoice == 2)
        {
            SetMCDialogue(thisMove.MCDialogue2);
            SetCCDialogue(thisMove.CCDialogue2);
        }
        else if(commChoice == 3)
        {
            SetMCDialogue(thisMove.MCDialogue3);
            SetCCDialogue(thisMove.CCDialogue3);
        }

    }

    private void SetMCDialogue(string dialogue)
    {
        MCText.text = dialogue;
    }

    private void SetCCDialogue(string dialogue)
    {
        CCText.text = dialogue;
    }
}
