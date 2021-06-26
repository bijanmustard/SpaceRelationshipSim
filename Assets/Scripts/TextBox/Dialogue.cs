using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code © Bijan Pourmand
 * Authored 6/25/21
 * Script for Dialogue NPC events. Contains text asset for dialogue, events
 * Supports up to 10 Dialogue Events.
 */

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    public TextAsset dialogueScript;

    //Event Caller
    public void Event(int i)
    {
        // 1. Call event
        switch (i)
        {
            case 0:
                DEvent0();
                break;
            case 1:
                DEvent1();
                break;
            case 2:
                DEvent2();
                break;
            case 3:
                DEvent3();
                break;
            case 4:
                DEvent4();
                break;
            case 5:
                DEvent5();
                break;
            case 6:
                DEvent6();
                break;
            case 7:
                DEvent7();
                break;
            case 8:
                DEvent8();
                break;
            case 9:
                DEvent9();
                break;
            default:
                Debug.Log("Event not found.");
                break;
        }
        // 2. End option event in TextboxManager
        TextboxManager.Instance.EndOptionWait();

    }

    //Events
    protected virtual void DEvent0() { Debug.Log("DEvent0"); }
    protected virtual void DEvent1() { Debug.Log("DEvent1"); }
    protected virtual void DEvent2() { Debug.Log("DEvent2"); }
    protected virtual void DEvent3() { Debug.Log("DEvent3"); }
    protected virtual void DEvent4() { Debug.Log("DEvent4"); }
    protected virtual void DEvent5() { Debug.Log("DEvent5"); }
    protected virtual void DEvent6() { Debug.Log("DEvent6"); }
    protected virtual void DEvent7() { Debug.Log("DEvent7"); }
    protected virtual void DEvent8() { Debug.Log("DEvent8"); }
    protected virtual void DEvent9() { Debug.Log("DEvent9"); }
}
