using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDialogue : Dialogue
{

    protected override string filename
    {
        get { return "Dialogues/sampleDialogue"; }
    }
    protected override void DEvent0()
    {
        //Move line pointer to line 7
        TextboxManager.Instance.SetLine(7);
        
    }

    protected override void DEvent1()
    {
        
    }

    protected override void DEvent5()
    {
       
    }

}
