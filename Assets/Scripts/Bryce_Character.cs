using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bryce_Character : MonoBehaviour
{
    public EventTriggers bryceTriggers;

    // No Day 1

    // Day 2 functions

    public void BrycesConfidenceIncrease()
    {
        bryceTriggers.brycesConfidenceCounter += 1;
    }

    public string BrycesLocation()
    {
        return bryceTriggers.bryceMovesScenes;
    }

    public bool BrycesFaith()
    {
        // Day 2

        // Alive
        if (bryceTriggers.dayTwoEnd == true)
        {
            if (bryceTriggers.brycesConfidenceCounter >= 2)
            {
                // Place her somewhere if there is a day 3
                return false;
            }

            // Dead
            else if (bryceTriggers.brycesConfidenceCounter < 0)
            {
                // Delete her game object on day 3 start 
                return true;
            }
        }

        // Should never get here
        Debug.Log("Error in Bryce");
        return false;

    }
}
