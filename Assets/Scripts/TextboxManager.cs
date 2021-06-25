using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/*
 * Code © Bijan Pourmand
 * Authored 6/25/21
 * Manager for textbox
 */

public class TextboxManager : MonoBehaviour
{

    //Vars & Refs
    Canvas myCanvas;
    public GameObject box;
    protected RectTransform boxRect;
    Text[] texts;
    protected Coroutine runIE;

    TextAsset asset;
    string[] lines;

    public float speed = 1f;
    public float sentenceBreak = 0.25f;

    private void Awake()
    {
        if (box == null) box = transform.GetChild(0).gameObject;
        boxRect = box.GetComponent<RectTransform>();
        myCanvas = GetComponent<Canvas>();
        texts = box.GetComponentsInChildren<Text>();
        ToggleTextbox(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ToggleTextbox(!myCanvas.enabled);
    }

    //Toggle whether textbox is enabled
    public void ToggleTextbox(bool tog)
    {
        myCanvas.enabled = tog;
    }

    //InitScript inits the text asset and its variables
    protected void InitScript(ref TextAsset ta)
    {
        //1. Split text
        lines = ta.ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
    
    }

    //IE for reading text asset script
    protected IEnumerator RunScript()
    {
        //1. Load text
        foreach(string s in lines)
        {
            //add chars
            foreach(char c in s)
            {
                texts[0].text += c.ToString();
                yield return new WaitForSeconds(speed / 5f);
            }
            //wait sentence break
            yield return new 
        }
        yield break;
       

    }
}
