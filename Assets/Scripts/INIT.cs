using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script for INIT scene
 */

public class INIT : MonoBehaviour
{
    private void Start()
    {
        SceneController.Instance.GoToScene("TitleScreen");
    }

    
}
