using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    private static Game_Manager instance;
    public static Game_Manager Instance { get { return instance; } }

    public int currentTimeLeft;
    public int maxTimeLeft;
    public int dayCount = 1;
    public Canvas canvas;
    public bool pdaVisible = false;

    public int currentMinute = 00;
    public int currentHour = 3;
    public int nextMinute;
    // Don't be an idiot like me... nextHour is useless but it makes me feel better.
    //Nah you a GENIUS :jimmyneutronface:
    public int nextHour;

    public Text time;
    public Text day;

    public bool test = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas.gameObject);
        }
    }

    private void OnDestroy()
    {
        //Destroy(canvas.gameObject);
    }

    private void Start()
    {
        if(test == false)
        {
            test = true;

            time.text = currentHour.ToString() + ":" + currentMinute.ToString("00");
            day.text = "Day " + dayCount.ToString();
        }
        
        
    }

    private void Update()
    {
        ShowPDA();
    }

    // Reduces the current time left to talk on a day.
    public void NPCTimeInteraction_Add()
    {
        currentTimeLeft -= 1;

        currentMinute += nextMinute;

        while (currentMinute >= 60)
        {
            currentHour += nextHour;
            currentMinute -= currentMinute;
        }

        time.text = currentHour.ToString() + ":" + currentMinute.ToString("00");
        if(currentTimeLeft < 1)
        {
            currentTimeLeft = maxTimeLeft;
            dayCount += 1;
            day.text = "Day " + dayCount.ToString();
        }

    }

   

    // Basically Pulls up the UI for the news report and time check
    public void ShowPDA()
    {
        if (Input.GetKeyDown("e") && pdaVisible == true)
        {
            canvas.enabled = false;
            pdaVisible = false;
        }
        else if (Input.GetKeyDown("e") && pdaVisible == false)
        {
            canvas.enabled = true;
            pdaVisible = true;
        }
    }

    public void EndDay()
    {

    }

    
}
