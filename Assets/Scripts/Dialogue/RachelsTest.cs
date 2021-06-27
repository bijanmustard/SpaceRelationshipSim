using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RachelsTest : Dialogue
{
    protected override string filename
    {
        get { return "RachelsTest"; }
    }
    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(7);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(10);
    }

    protected override void DEvent5()
    {

    }

}
