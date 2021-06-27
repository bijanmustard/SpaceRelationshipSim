using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;
    public int nextSceneIndex;
    public int currentScene;

    public GameObject moveCanvas;
    public GameObject moveGameManager;


    private void Update()
    {
        moveCanvas = GameObject.Find("Canvas");
        moveGameManager = GameObject.Find("Game Manager");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Starting_Position_Value.initialValue = playerPosition;
            Starting_Position_Value.transitionNumber += 1;
            SceneController.Instance.GoToScene(sceneToLoad);

        }
    }

    
}
