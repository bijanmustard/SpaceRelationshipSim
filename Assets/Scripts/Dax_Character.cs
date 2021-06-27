using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dax_Character : MonoBehaviour
{
    public EventTriggers daxTriggers = GameObject.Find("Game Manager").GetComponent<EventTriggers>();



    // Day one Functions


    public string DaxsLocation()
    {
        return daxTriggers.daxMovesScene;
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
