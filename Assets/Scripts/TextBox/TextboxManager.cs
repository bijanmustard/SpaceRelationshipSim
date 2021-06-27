using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;

/*
 * Code © Bijan Pourmand
 * Authored 6/25/21
 * Manager for textbox
 */

/*
 * METATEXT GLOSSARY
 * <&t(string)> -- Update name text
 * <&w> -- Trigger break
 * <&s(int)> -- set read speed
 * <&x> -- Exit text event
 * {<1..>;<2..>;..<n..>} -- Options (limit of four)
 * <&d(int)> -- change expression (for initimate dialogue)
 * <&e(int)> -- call (int) event
 */

public class TextboxManager : MonoBehaviour
{

    //Vars & Refs
    private static TextboxManager instance;
    public static TextboxManager Instance {get {return instance;}}

    protected DialogueCanvas dCanvas;

    protected char[] punctuation = { '.', '?', '!' };

    Canvas myCanvas;
    GameObject box;
    RectTransform boxRect;
    GameObject breakImg;
    protected Text[] texts;
    protected Button[] buttons;
    protected Player_Movement playerMove;
    protected AudioSource audio;

    //Text sounds
    public AudioClip charSound;

    //Button actions
    Action[] buttActs = new Action[4];

    public Coroutine runIE;
    protected bool isRunning = false;
    public bool IsRunning { get { return isRunning; } }

    public Dialogue curDialogue;
    protected TextAsset asset;
    string[] lines;

    protected float speed = 3f;
    public float speedMultiplier = 2f;  //for holding down space
    public float sentenceBreak = 0.2f;
    const int MAXCHARS = 215;

    protected bool isBreak = false;
    protected bool isExit = false;
    protected bool waitForOption = false;

    protected int linePointer = 0;


    private void Awake()
    {
        //Singleton
        if (instance != null && instance != this) Destroy(gameObject);
        else { instance = this; DontDestroyOnLoad(gameObject); }

        //Get refs
        if (box == null) box = transform.Find("Box").gameObject;
        boxRect = box.GetComponent<RectTransform>();
        myCanvas = GetComponent<Canvas>();
        texts = box.GetComponentsInChildren<Text>();
        breakImg = box.transform.Find("Break").gameObject;
        buttons = transform.Find("Buttons").GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(delegate { TriggerDEvent(0); });
        dCanvas = FindObjectOfType<DialogueCanvas>();
        playerMove = FindObjectOfType<Player_Movement>();
        audio = GetComponent<AudioSource>();

        //Disable textbox
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
            ToggleButtons(false);
            linePointer = 0;
            texts[0].text = "";
            texts[1].text = "";
        }
        
    }

    //ToggleButtons enables/disables selection buttons.
    protected void ToggleButtons(bool tog)
    {
        foreach (Button b in buttons)
            b.gameObject.SetActive(tog);
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
    public void StartDialogue(Dialogue myDia)
    {
        //0. Lock player movement
        if (playerMove == null) playerMove = FindObjectOfType<Player_Movement>();
        playerMove.ToggleMove(false);

        //1. Initialize
        InitDialogue(ref myDia);
        //2. Open text box
        ToggleTextbox(true);
        //3. Start Coroutine
        if (!isRunning) runIE = StartCoroutine(RunScript());
    }


    //<><> EVENT FUNCTIONS <><>

    // SetLine is called by events to set the linePointer.
    public void SetLine(int line)
    {
        linePointer = Mathf.Clamp(line-1, 0, lines.Length);
    }

    // EndOption is called in Dialogue to end the optionWait bool
    public void EndOptionWait() { waitForOption = false;}

    //<><><><><><><><><><><><><>




    //CheckOptions checks if the input line is an options line. Displays options if true.
    protected bool CheckOptions(string line)
    {
        //else if options...
         if (line.Contains("{"))
        {
            //enable options flag for text IE
            waitForOption = true;
            //format line into array
            string ops = line.TrimStart('{');
            ops = ops.TrimEnd('}');
            Debug.Log(ops);
            string[] options = ops.Split(';');
            LoadOptions(options);
            return true;
        }
        return false;
    }

    //CheckMetaTag checks a string for a meta tag. Performs functions accordingly.
    protected bool CheckMetaTag(string myWord)
    {
        //1. If string starts with meta tag....
        if (myWord.Contains("<&"))
        {
            char[] chars = myWord.ToCharArray();
            //2. Title Update
            if (chars[2] == 't')
            {
                string myName = myWord;
                myName = myName.Trim('>');
                myName = myName.Remove(0, 3);
                //Replace spaces
                myName = myName.Replace("&'_'", " ");
                Debug.Log(myName);
                texts[0].text = myName;
            }

            //3. Break
            else if (chars[2] == 'w') isBreak = true;

            //4. Speed
            else if (chars[2] == 's')
            {
                //extract speed int
                string spd = myWord;
                spd = spd.Trim('>');
                spd = spd.Remove(0, 3);

                //set speed
                
                speed = int.Parse(spd);

            }

            //5. DialogEvents
            else if (chars[2] == 'e')
            {
                //Call event
                int ev = (int)Char.GetNumericValue(chars[3]);
                curDialogue.Event(ev);
            }

            //6. Force exit
            else if (chars[2] == 'x') isExit = true;

            //7. Change dCanvas expression
            else if (chars[2] == 'd')
            {
                if(dCanvas.isCanvas)
                {
                    //Extract idx
                    int idx = (int)Char.GetNumericValue(chars[3]);
                    dCanvas.ChangeExpression(idx);
                }
            }

            //Return true if was meta
            return true;
        }

        return false;
    }

    //LoadOptions loads the dialogue option buttons with event listeners.
    protected void LoadOptions(string[] ops)
    {
        //1. Get button info
        for(int i = 0; i < ops.Length; i++)
        {
            //Parse as char array
            char[] c = ops[i].ToCharArray();
            //2. check event code and add listener
            int ev = (int)Char.GetNumericValue(c[1]);
            buttActs[i] = delegate { TriggerDEvent(ev); };

            //3. Get text from string
            string opt = ops[i];
            opt = opt.Trim('>');
            opt = opt.Remove(0, 2);
            //4. set to button text
            buttons[i].GetComponentInChildren<Text>().text = opt;
            //5. enable button
            buttons[i].gameObject.SetActive(true);
        }
    }

    //Button click functions
    public void Button1Event()
    {
        buttActs[0].Invoke();
    }

    public void Button2Event()
    {
        buttActs[1].Invoke();
    }

    public void Button3Event()
    {
        buttActs[2].Invoke();
    }

    public void Button4Event()
    {
        buttActs[3].Invoke();
    }


    //TriggerDEvent is a listner for buttons to call curDialgoue's events.
    public void TriggerDEvent(int val)
    {
        curDialogue.Event(val);
        
    }

    //IE for reading text asset script
    protected IEnumerator RunScript()
    {
        isRunning = true;
        int charCount = 0;
        isExit = false;
        bool endDialogue = false;

        //Add audio
        if (charSound != null) audio.clip = charSound;

        //1. Load text
        while (!endDialogue)
        {
            
            //Get next line 
            string s = lines[linePointer];
            //If next line isn't an options line...
            if (!CheckOptions(s))
            {
                if (isExit) break;
                //Split line into words
                string[] words = s.Split(' ');
                foreach (string w in words)
                {
                    bool eos = false;
                    if (isExit) break;

                    //If word is not meta tag...
                    if (!CheckMetaTag(w))
                    {
                        //Used to make the textbox sound play half aws often
                        bool playSound = true;
                        //If word won't fit in textbox, clear textbox
                        if (w.ToCharArray().Length + charCount > MAXCHARS)
                        {
                            texts[1].text = "";
                            charCount = 0;
                        }
                        //Add word
                        foreach (char c in w)
                        {
                            //add char and increment char count
                            texts[1].text += c.ToString();
                            charCount++;
                            //play char sound
                            if (playSound)
                            {
                                audio.Play();
                                playSound = false;
                            }
                            else playSound = true;
                            //wait for speed
                            speedMultiplier = (Input.GetKey(KeyCode.Space) ? 0.5f : 1);
                            yield return new WaitForSeconds(5 / (speed * 50f) * speedMultiplier);
                            //if char is last and is punctuation, set EOS flag
                            if (c == w[w.Length - 1] && (Array.Exists(punctuation, p => p == c)
                                || w == words[words.Length - 1])) eos = true;
                        }
                        //add space between words
                        texts[1].text += " ";
                        charCount++;
                        //If not EOS
                        if (!eos) yield return new WaitForSeconds(5 / (speed * 50f) * speedMultiplier);
                        else yield return new WaitForSeconds(sentenceBreak);
                        if (audio.isPlaying) audio.Stop();
                        

                    }
                }
            }

            //else, wait for option to be chosen
            else
            {
                while (waitForOption) yield return null;
                texts[1].text = "";
                ToggleButtons(false);
                continue;
            }

            // if is break, wait
            if (isBreak)
            {
                breakImg.SetActive(true);
                
            }
            while (isBreak)
            {
                //Wait for input
                if (Input.GetButtonDown("Submit"))
                {
                    isBreak = false;
                    //clear text
                    charCount = 0;
                    texts[1].text = "";
                    breakImg.SetActive(false);
                }
                else yield return null;
            }

            //Increment line pointer
            linePointer++;
                //If linePointer is larger than lines length, end dialogue.
                if (linePointer >= lines.Length) endDialogue = true;
            
        }
        // End break
        isBreak = true;
        breakImg.SetActive(true);
       
        while (isBreak)
        {
            //Wait for input
            if (Input.GetButtonDown("Submit"))
            {
                isBreak = false;
                //clear text
                texts[1].text = "";
                breakImg.SetActive(false);
            }
            else yield return null;
        }
        Debug.Log("Text done!");
        OnTextboxExit();
        yield return null;

    }

    //OnTextboxExit is called when the final break is made to close the textbox.
    protected void OnTextboxExit()
    {
        //1. Set isRunning to false
        isRunning = false;
        //2. Close textbox
        ToggleTextbox(false);
        //3. Disable dialogue canvas if applicable
        if (dCanvas.isCanvas) dCanvas.DisableCanvas();
        //4. unlock player movement
        playerMove.ToggleMove(true);
        
    }
}
