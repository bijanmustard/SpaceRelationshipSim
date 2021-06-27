using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dax_Day1_0 : Dialogue
{
    protected override string filename
    {
        get { return "Dax/Dax_Day1_0"; }
    }

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
    protected override void DEvent5()
    {
        //Queue scene transition with cutscene ID (?)
        dax_Character.daxTriggers.daxMoves = true;
        SceneController.Instance.GoToScene("Bar");
        dax_Character.SpawnDax();



    }
}
