using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Day_Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneController.Instance.GoToScene("TelevisionReport");
    }
}
