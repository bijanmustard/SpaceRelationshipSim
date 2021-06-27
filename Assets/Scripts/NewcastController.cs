using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code © (a very tired) Bijan Pourmand
 * Authored 6/27/21 @ 2:37am
 * SCript for Newscast scene, displays different events based on day
 */

public class NewcastController : MonoBehaviour
{

    Dialogue[] news;

    private void Awake()
    {
        news = GetComponentsInChildren<Dialogue>();
    }

    void Update()
    {
        if (Game_Manager.Instance.dayCount == 2) TextboxManager.Instance.StartDialogue(news[0]);
        else if (Game_Manager.Instance.dayCount == 3) TextboxManager.Instance.StartDialogue(news[1]);
    }

}
