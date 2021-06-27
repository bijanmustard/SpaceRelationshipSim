using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bryce_Day2_0 : Dialogue
{

    protected override string filename
    {
        get { return "Bryce/Bryce_Day2_0"; }
    }

    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(6);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(10);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetLine(15);
    }

    protected override void DEvent3()
    {
        TextboxManager.Instance.SetLine(21);
    }

    protected override void DEvent4()
    {
        //bar
    }

    protected override void DEvent5()
    {
        //karaoke
    }

    protected override void DEvent6()
    {
        //pavillion
    }
}
