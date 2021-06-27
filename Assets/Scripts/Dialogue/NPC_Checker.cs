using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to be attached to NPCS whose state depends on Game_Manager variables
 * eg. position, active, current dialouge, etc.\
 */

public class NPC_Checker : MonoBehaviour
{

    //Bryce example
    private void Awake()
    {
        // 1. If Bryce is dead, destroy NPC
        if (Game_Manager.Instance.flags.bryceDeath) Destroy(gameObject);
        //2. If Bryce is not dead...
        else
        {
            //3. ...check what day it is
            //If 1st day...
            if(Game_Manager.Instance.dayCount == 0)
            {
                //Put me in my Day 1 position on this map

                //Initialize my dialogue
                Dialogue myDia = gameObject.AddComponent<Dialogue>();
               
            }
            //If second day...
            else if(Game_Manager.Instance.dayCount == 1)
            {
                //Put me in Day 2 position for this map

                //Initialize my day 2 dialogue
                Dialogue myDia = gameObject.AddComponent<Dialogue>();
                TextAsset t = Resources.Load<TextAsset>("Texts/day2.txt");
                myDia.dialogueScript = t;
            }
        }
    }

}
