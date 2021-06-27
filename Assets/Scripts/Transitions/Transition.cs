using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Code © Bijan Pourmand
 * Authored 4/6/21
 * Base script for transition objs. To be used by TransitionManager.
 */

public class Transition : MonoBehaviour
{
    //vars
    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected float speed = 1;
    

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // In() is called when transitioning back into a scene
    public virtual void In() { }
    public virtual void In(float speed) { }

    // Out is called when transitioniong out of a scene.
    public virtual void Out() { }
    public virtual void Out(float speed) { }
    public virtual void Out(Color c, float speed = 1) { }

    // SignalTransitioning sets the transitioning bool in the manager to let it know a transition has started/ended. Is an animation event.
    // False: 0
    // True: all numbers <> 0
    public void SignalTransitioning(int val)
    {
        TransitionManager.Instance.SetTransitioning(Convert.ToBoolean(val));
    }
}

