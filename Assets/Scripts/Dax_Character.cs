using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dax_Character : MonoBehaviour
{
    public EventTriggers daxTriggers;



    // Day one Functions
<<<<<<< HEAD
    public GameObject daxDay1Bar;
=======
>>>>>>> parent of ad51d49 (Idk part 2)

    

<<<<<<< HEAD

    

    public void SpawnDax()
    {
        if (daxTriggers.daxMoves == true)
        {
            daxDay1Bar.SetActive(true);

        }
        else
        {
            daxDay1Bar.SetActive(false);
        }
    }

=======
>>>>>>> parent of ad51d49 (Idk part 2)
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
