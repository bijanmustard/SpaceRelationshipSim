using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bryce_Day2_Bar : Dialogue
{



    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(12);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(14);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetLine(16);
    }
}