using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bryce_Day2_Pavillion : Dialogue
{

    protected override string filename
    {
        get { return "Bryce/Bryce_Day2_Pavillion"; }
    }

    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(7);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(9);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetLine(11);
    }
}