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


    //Events
    public virtual void DEvent0() { Debug.Log("DEvent0"); }
    public virtual void DEvent1() { Debug.Log("DEvent1"); }
    public virtual void DEvent2() { Debug.Log("DEvent2"); }
    public virtual void DEvent3() { Debug.Log("DEvent3"); }
    public virtual void DEvent4() { Debug.Log("DEvent4"); }
    public virtual void DEvent5() { Debug.Log("DEvent5"); }
    public virtual void DEvent6() { Debug.Log("DEvent6"); }
    public virtual void DEvent7() { Debug.Log("DEvent7"); }
    public virtual void DEvent8() { Debug.Log("DEvent8"); }
    public virtual void DEvent9() { Debug.Log("DEvent9"); }
}
