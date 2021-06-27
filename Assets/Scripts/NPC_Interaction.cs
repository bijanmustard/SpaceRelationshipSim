using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{
    public GameObject exclamationMark;
    public Game_Manager Game_Manager;
    public DialogueCanvas dCanvas;

    //Dialogue Vars
    Dialogue myDialogue;
    public DiaSprites mySprites;
    public bool isDialogue = false;


    private void Awake()
    {
        if (myDialogue == null) myDialogue = GetComponent<Dialogue>();
        if (myDialogue == null) { Debug.Log("ERROR! No dialogue script attached to NPC!"); return; }
        dCanvas = FindObjectOfType<DialogueCanvas>();

    }

    private void Start()
    {
        Game_Manager = GameObject.FindObjectOfType<Game_Manager>().GetComponent<Game_Manager>();
        dCanvas = GameObject.FindObjectOfType<DialogueCanvas>().GetComponent<DialogueCanvas>(); ;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exclamationMark.SetActive(true);

            if (Input.GetKey(KeyCode.Q))
            {
                //Trigger Event
                StartDialogue();

            }
        }

    }

    //StartDialogue is called to start a dialogue event.
    public void StartDialogue()
    {
        
        if (!TextboxManager.Instance.IsRunning)
        {
            if (mySprites != null) dCanvas.EnableCanvas(ref mySprites);
            Game_Manager.NPCTimeInteraction_Add();
            TextboxManager.Instance.StartDialogue(myDialogue);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exclamationMark.SetActive(false);
            

        }
    }
}
