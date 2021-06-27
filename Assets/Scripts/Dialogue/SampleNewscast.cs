using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleNewscast : Dialogue
{

    public bool isBryceDead = false;

    protected override void DEvent0()
    {
        if (!isBryceDead) TextboxManager.Instance.SetLine(16);
        else TextboxManager.Instance.SetLine(9);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(20);
    }
}
