using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Code © Bijan Pourmand
 * Authored 4/9/21
 * Static controller for scene management. Works with transition manager.
 */

public class SceneController : MonoBehaviour
{

    private static SceneController instance;
    public static SceneController Instance { get { return instance; } }
    Coroutine curRoutine;


    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else { instance = this; DontDestroyOnLoad(gameObject); }
    }

    // GoToScene() is called to go to a specified scene.
    public  void GoToScene(int idx) {
        //1. Stop current coroutine
        if (curRoutine != null)
        {
            StopCoroutine(curRoutine);
           
        }
        //2.Reset transitioning bool
        TransitionManager.Instance.SetTransitioning(false);
        curRoutine = StartCoroutine(GoToIE(idx)); 
    }

    public void GoToScene(string str) {
        //1. Stop current coroutine
        if (curRoutine != null)
        {
            StopCoroutine(curRoutine);
           
        }
        //2.Reset transitioning bool
        TransitionManager.Instance.SetTransitioning(false);
        curRoutine = StartCoroutine(GoToIE(str)); 
    }
    
     //GetCurScene returns the current scene
     public Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }

    //GoToIE() is the IE for GoToScene.
   IEnumerator GoToIE(int idx)
    {
        Player_Movement move = FindObjectOfType<Player_Movement>();
        if (move != null) move.LockMovement(true);

        //1. start out transition
        TransitionManager.Instance.TransitionOut(0, 1);
            //2. Wait for transition to finish
            while (TransitionManager.Instance.isTrans) yield return null;
            Debug.Log("Loading scene....");
            //3. LoadScene
            SceneManager.LoadScene(idx);
        //4. TransitionIn
        TransitionManager.Instance.TransitionIn();
        //5.Unlock player movement
        if (move != null) move.LockMovement(false);
    }

    //GoToIE() is the IE for GoToScene.
    IEnumerator GoToIE(string str)
    {
        Player_Movement move = FindObjectOfType<Player_Movement>();
        if (move != null) move.LockMovement(true);

        //1. start out transition
        TransitionManager.Instance.TransitionOut(0, 1);
        //2. Wait for transition to finish
        while (TransitionManager.Instance.isTrans) yield return null;
        Debug.Log("Loading scene....");
        //3. LoadScene
        SceneManager.LoadScene(str);
        //4. TransitionIn
        TransitionManager.Instance.TransitionIn();
        if (move != null) move.LockMovement(false);
    }

}
