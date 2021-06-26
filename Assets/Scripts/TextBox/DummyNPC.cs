using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyNPC : MonoBehaviour
{
    public Dialogue dia;
    private void Awake()
    {
        dia = GetComponent<Dialogue>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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