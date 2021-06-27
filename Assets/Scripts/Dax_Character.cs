using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dax_Character : MonoBehaviour
{
    public EventTriggers daxTriggers;



    // Day one Functions
    public GameObject daxDay1Bar;
    public GameObject daxDay1Plaza;


    public void DaxsMovesDay1()
    {
        //GameObject dax;
        SceneManager.LoadScene("Bar",LoadSceneMode.Additive);

        //SceneManager.MoveGameObjectToScene()
    }

    public void DaxsLocation(string location)
    {
        daxTriggers.daxMovesScene = location;
        daxTriggers.daxMoves = true;
    }


    public bool DaxsFaith()
    {
        
        if (daxTriggers.dayOneEnd == true)
        {
            // Alive
            if (daxTriggers.daxDeath == false)
            {
                // Place him in the scene somewhere  on day 2 start
                return false;
            }

            // Dead
            else if (daxTriggers.daxDeath == true)
            {
                // Delete his game object on day 2 start 
                return false;
            }

            
        }

        // Should never get here
        Debug.Log("Error in Dax");
        return false;
    }

}
