using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueClass
{
    public string charName;
    [TextArea(3, 10)]
    public string[] sentences;
}
