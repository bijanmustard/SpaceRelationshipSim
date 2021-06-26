using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyNPC : MonoBehaviour
{
    public Dialogue dia;
    public DiaSprites myDIASPR;

    private void Awake()
    {
        dia = GetComponent<Dialogue>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !TextboxManager.Instance.IsRunning)
        {
            StartDialogue();
        }
    }

    //StartDialogue is called to start the dialogue event.
    public void StartDialogue()
    {
        TextboxManager.Instance.StartDialogue(dia);
    }

}
