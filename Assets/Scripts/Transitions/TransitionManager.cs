using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Code © Bijan Pourmand
 * Authored 4/6/21
 * Manager for Transitions. Contains ref's to all child transition objs and functions to use them.
 */

public class TransitionManager : MonoBehaviour
{
    private static TransitionManager instance;
    public static TransitionManager Instance { get {return instance;}}
    //transition refs
    Coroutine curRoutine;
    Transition[] transitions;
    public int curTransition;
    [SerializeField]
    protected bool isTransitioning;
    public bool isTrans { get { return isTransitioning; } }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //Set order of transitions before making array
        transform.Find("FadeIO").SetSiblingIndex(0);
        transitions = GetComponentsInChildren<Transition>();
        
    }
    

    // TransitionOut is called to transition out 
    public void TransitionOut(int type, float speed = 0) {
        isTransitioning = true;
        //1. fade out
        curTransition = type;
        if (speed > 0) transitions[type].Out(speed);
        else transitions[type].Out();
    }

    public void TransitionOut(int type, Color c, float speed = 0)
    {
        isTransitioning = true;
        //1. fade out
        curTransition = type;
        if (speed > 0) transitions[type].Out(c,speed);
        else transitions[type].Out(c);
    }

    // TransitionIn is called to transition in
    public void TransitionIn(int type = -1, float speed = 0)
    {
        
        //1. fade in
        int cur = curTransition;
        if (type > -1) cur = type;
        if (speed > 0) transitions[cur].In(speed);
        else transitions[cur].In();
    }

    // SetTransitioning sets the transitioning bool. Should only be called from transition anim functions.
    public void SetTransitioning(bool b) { isTransitioning = b; }

}
