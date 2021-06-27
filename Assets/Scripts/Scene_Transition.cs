using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;


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
