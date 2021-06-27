using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia_Newscast1 : Dialogue
{



    protected override void DEvent0()
    {
        if (!Game_Manager.Instance.flags.daxDeath) TextboxManager.Instance.SetLine(5);
        else TextboxManager.Instance.SetLine(12);
    }

    protected override void DEvent1()
    {
        TextboxManager.Instance.SetLine(18);
    }

}
