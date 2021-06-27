using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia_Newscast2 : Dialogue
{

   

    protected override void DEvent0()
    {
        //if (!Game_Manager.Instance.flags.bryceDeath) TextboxManager.Instance.SetLine(16);
        //else TextboxManager.Instance.SetLine(9);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(20);
    }

    protected override void DEvent2()
    {
        TextboxManager.Instance.SetExitEvent(delegate { SceneController.Instance.GoToScene("Bar"); });
    }
}

