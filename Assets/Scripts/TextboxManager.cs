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

/*
 * METATEXT GLOSSARY
 * <&t(string)> -- Update name text
 * <&w> -- Trigger break
 * <&sp(int)> -- set read speed
 */

public class TextboxManager : MonoBehaviour
{

    //Vars & Refs
    Canvas myCanvas;
    public GameObject box;
    protected RectTransform boxRect;
    GameObject breakImg;
    protected Text[] texts;
    protected Coroutine runIE;
    protected bool isRunning = false;

    public Dialogue curDialogue;
    protected TextAsset asset;
    string[] lines;

    public float speed = 1f;
    public float sentenceBreak = 0.2f;
    const int MAXCHARS = 240;
    protected bool isBreak = false;

    private void Awake()
    {
        if (box == null) box = transform.GetChild(0).gameObject;
        boxRect = box.GetComponent<RectTransform>();
        myCanvas = GetComponent<Canvas>();
        texts = box.GetComponentsInChildren<Text>();
        breakImg = box.transform.Find("Break").gameObject;
        ToggleTextbox(false);
    }


    //Toggle whether textbox is enabled
    public void ToggleTextbox(bool tog)
    {
        myCanvas.enabled = tog;

        if (!tog)
        {
            if (runIE != null) StopCoroutine(runIE);
            breakImg.SetActive(false);
        }
        
    }

    //InitScript inits the text asset and its variables
    protected void InitDialogue(ref Dialogue cur)
    {
        //1. Set dialogue
        curDialogue = cur;
        //2. Initialize text asset
        lines = curDialogue.dialogueScript.ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        texts[0].text = "";
        texts[1].text = "";

    }

    // StartDialoge is called by an NPC to trigger a dialogue.
    public void StartDialogue(ref Dialogue myDia)
    {
        //1. Initialize
        InitDialogue(ref myDia);
        //2. Open text box
        ToggleTextbox(true);
        //3. Start Coroutine
        if (!isRunning) runIE = StartCoroutine(RunScript());
    }

    //CheckMetaTag checks a string for a meta tag. Performs functions accordingly.
    protected bool CheckMetaTag(string tag)
    {
        //1. If string starts with meta tag....
        if (tag.Contains("<&"))
        {
            char[] chars = tag.ToCharArray();
            //2. Title Update
            if (chars[2] == 't')
            {
                string myName = tag;
                myName = myName.Trim('>');
                myName = myName.Remove(0, 3);
                texts[0].text = myName;
            }

            //3. Break
            else if (chars[2] == 'w') isBreak = true;

            //4. Speed
            else if(chars[2] == 's')
            {
                //extract speed int
                string spd = tag;
                spd = spd.Trim('>');
                spd = spd.Remove(0, 3);
                
                //set speed
                Debug.Log(spd);
                speed = int.Parse(spd);

            }

            //5. DialogEvents
            else if (chars[2] == 'e')
            {
                switch (chars[3])
                {
                    case '0':
                        curDialogue.DEvent0();
                        break;
                    case '1':
                        curDialogue.DEvent1();
                        break;
                    case '2':
                        curDialogue.DEvent2();
                        break;
                    case '3':
                        curDialogue.DEvent3();
                        break;
                    case '4':
                        curDialogue.DEvent4();
                        break;
                    case '5':
                        curDialogue.DEvent5();
                        break;
                    case '6':
                        curDialogue.DEvent6();
                        break;
                    case '7':
                        curDialogue.DEvent7();
                        break;
                    case '8':
                        curDialogue.DEvent8();
                        break;
                    case '9':
                        curDialogue.DEvent9();
                        break;

                }
            }


            //Return true if was meta
            return true;
        }
        return false;
    }

    //IE for reading text asset script
    protected IEnumerator RunScript()
    {
        isRunning = true;
        int charCount = 0;

        //1. Load text
        foreach(string s in lines)
        {
         
            //Split line into words
            string[] words = s.Split(' ');
            foreach (string w in words)
            {
                //If word is not meta tag...
                if (!CheckMetaTag(w))
                {
                    
                    //If word won't fit in textbox, clear textbox
                    if (w.ToCharArray().Length + charCount > MAXCHARS)
                    {
                        texts[0].text = "";
                        charCount = 0;
                    }
                    //Add char
                    foreach (char c in w)
                    {
                        texts[1].text += c.ToString();
                        charCount++;
                        yield return new WaitForSeconds(speed / 10f);
                    }

                    //wait word break
                    texts[1].text += " ";
                    yield return new WaitForSeconds(sentenceBreak);
                }
                // if is break, wait
                if (isBreak) breakImg.SetActive(true);
                while (isBreak)
                {
                    //Wait for input
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        isBreak = false;
                        //clear text
                        texts[1].text = "";
                        breakImg.SetActive(false);
                    }
                    else yield return null;
                }
            }   
        }
        Debug.Log("Text done!");
        isRunning = false;
        yield break;
       

    }
}
