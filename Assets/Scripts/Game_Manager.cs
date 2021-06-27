using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EventTriggers))]
public class Game_Manager : MonoBehaviour
{

    private static Game_Manager instance;
    public static Game_Manager Instance { get { return instance; } }

    public int currentTimeLeft;
    public int maxTimeLeft;
    public int dayCount;
    public Canvas canvas;
    public bool pdaVisible = false;

    public int currentMinute = 00;
    public int currentHour = 3;
    public int nextMinute;
    // Don't be an idiot like me... nextHour is useless but it makes me feel better.
    //Nah you a GENIUS :jimmyneutronface:
    public int nextHour;
    public float blinkRateCooldown;
    private float blinkCountdown;
    private float timer;
    private bool blinking;


    public Text time;
    public UnityEngine.UI.Image day;

    
    public Sprite[] daySprites;

    public EventTriggers flags;


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

        flags = GetComponent<EventTriggers>();
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
            day.sprite = daySprites[dayCount];
        }
        
        
    }

    private void Update()
    {

        timer += Time.deltaTime;

        if(blinking == true && blinkCountdown < timer)
        {
            blinking = false;
            blinkCountdown = timer + blinkRateCooldown;
            time.text = currentHour.ToString() + " " + currentMinute.ToString("00");
        }

        else if(blinking == false && blinkCountdown < timer)
        {
            blinking = true;
            blinkCountdown = timer + blinkRateCooldown;
            time.text = currentHour.ToString() + ":" + currentMinute.ToString("00");
        }

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
            
            day.sprite = daySprites[dayCount];
        }

    }

   



    public void EndDay()
    {
        dayCount += 1;
        SceneController.Instance.GoToScene("TelevisionReport");
        
    }

    
}
