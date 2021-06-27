using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bryce_Day2_0 : Dialogue
{

    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(5);
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
        //invite bryce to bar
    }
    protected override void DEvent5()
    {
        //invite bryce to karaoke
    }
    protected override void DEvent6()
    {
        //invite bryce to pavilion
    }

}
