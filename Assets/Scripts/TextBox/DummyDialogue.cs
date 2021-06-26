using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDialogue : Dialogue
{
    public override void DEvent0()
    {
        
        TextboxManager.Instance.SetLine(0);
    }
}
