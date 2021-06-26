using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{
    public GameObject exclamationMark;
    public Game_Manager Game_Manager;

    


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exclamationMark.SetActive(true);
        }

        if (Input.GetKeyDown("q"))
        {
            Game_Manager.NPCTimeInteraction_Add();
            Debug.Log("Yea");
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
