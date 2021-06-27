using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : Dialogue
{

    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(7);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(25);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetLine(15);
    }
    protected override void DEvent3()
    {
        TextboxManager.Instance.SetLine(28);
    }
    protected override void DEvent4()
    {
        TextboxManager.Instance.SetLine(33);
    }
    protected override void DEvent5()
    {
        TextboxManager.Instance.SetLine(19);
    }
    protected override void DEvent6()
    {
        TextboxManager.Instance.SetLine(22);
    }


}