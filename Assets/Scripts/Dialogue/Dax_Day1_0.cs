using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dax_Day1_0 : Dialogue
{
    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(5);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(9);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetLine(14);
        //Set bool here <-------
    }

    //Queue bar transition
    protected override void DEvent3()
    {
        //Queue scene transition with cutscene ID (?)
    }
}