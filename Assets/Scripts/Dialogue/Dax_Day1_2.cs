using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dax_Day1_2 : Dialogue
{
    protected override void DEvent0()
    {
        TextboxManager.Instance.SetLine(6);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(9);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetLine(13);
        //Set bool here <-------
    }

    //Queue bar transition
    protected override void DEvent3()
    {
        TextboxManager.Instance.SetLine(16);
    }
    protected override void DEvent4()
    {
        TextboxManager.Instance.SetLine(19);
    }
    protected override void DEvent5()
    {
        TextboxManager.Instance.SetLine(23);
    }
    protected override void DEvent6()
    {
        TextboxManager.Instance.SetLine(27);
    }
    protected override void DEvent7()
    {
        //change scene here
    }
}