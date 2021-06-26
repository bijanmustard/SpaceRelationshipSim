using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDialogue : Dialogue
{
    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(9);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(18);
    }
}
