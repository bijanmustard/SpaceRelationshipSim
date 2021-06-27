using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code © Bijan Pourmand
 * Authored 6/25/21
 * Script for Dialogue NPC events. Contains text asset for dialogue, events
 * Supports up to 10 Dialogue Events.
 */

public abstract class Dialogue : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    public Dax_Character dax_Character;

    [SerializeField]
    public Bryce_Character bryce_Character;

=======
>>>>>>> parent of ad51d49 (Idk part 2)
    public TextAsset dialogueScript;

    [SerializeField]
    protected abstract string filename { get; }

    private void Awake()
    {
        Debug.Log(string.Format("Texts/{0}", filename));
        //1. Set text asset
        dialogueScript = Resources.Load<TextAsset>(string.Format("Texts/{0}", filename));
    }

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
            case 10:
                DEvent10();
                break;
            case 11:
                DEvent11();
                break;
            case 12:
                DEvent12();
                break;
            case 13:
                DEvent13();
                break;
            case 14:
                DEvent14();
                break;
            case 15:
                DEvent15();
                break;
            case 16:
                DEvent16();
                break;
            case 17:
                DEvent17();
                break;
            case 18:
                DEvent18();
                break;
            case 19:
                DEvent19();
                break;
            case 20:
                DEvent20();
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
    protected virtual void DEvent10() { Debug.Log("DEvent10"); }
    protected virtual void DEvent11() { Debug.Log("DEvent11"); }
    protected virtual void DEvent12() { Debug.Log("DEvent12"); }
    protected virtual void DEvent13() { Debug.Log("DEvent13"); }
    protected virtual void DEvent14() { Debug.Log("DEvent14"); }
    protected virtual void DEvent15() { Debug.Log("DEvent15"); }
    protected virtual void DEvent16() { Debug.Log("Devent16"); }
    protected virtual void DEvent17() { Debug.Log("DEvent17"); }
    protected virtual void DEvent18() { Debug.Log("DEvent18"); }
    protected virtual void DEvent19() { Debug.Log("DEvent19"); }
    protected virtual void DEvent20() { Debug.Log("DEvent20"); }
}
