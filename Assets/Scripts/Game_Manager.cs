using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public int currentTimeLeft;
    public int maxTimeLeft;
    public int dayCount = 1;
    public Canvas canvas;
    public bool pdaVisible = false;

    public int currentMinute = 00;
    public int currentHour = 3;
    public int nextMinute;
    // Don't be an idiot like me... nextHour is useless but it makes me feel better.
    public int nextHour;

    public Text time;
    public Text day;

    

    private void Start()
    {

        time.text = currentHour.ToString() + ":" + currentMinute.ToString("00") + " a.m";
        day.text = "Day " + dayCount.ToString();
        canvas.enabled = false;
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

        time.text = currentHour.ToString() + ":" + currentMinute.ToString("00") + " a.m";
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

    
}
