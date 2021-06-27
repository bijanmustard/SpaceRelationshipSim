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

    public Dialogue[] news;
    bool hasStart;

    private void Awake()
    {
        news = GetComponentsInChildren<Dialogue>();
    }

    private void Start()
    {
        if (!hasStart)
        {
            if (Game_Manager.Instance.dayCount == 1)
            {
                TextboxManager.Instance.StartDialogue(news[1]);
                hasStart = true;
            }
            else if (Game_Manager.Instance.dayCount == 2)
            {
                TextboxManager.Instance.StartDialogue(news[1]);
                hasStart = true;
            }
        }
    }

}
