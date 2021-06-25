using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    /*--------------How this Code Works---------------
     *  The camera lerps towards the players current position.
     *  
     *  The 4 transform values are used to create camera bounds for the edge of the map.
            When the camera algins with them it will clamp and stop at that spot and won't move.
     * 
     * 
     * 
     * 
     */


    public Transform target;
    public float smoothing;
    //public Vector2 maxPosition;
    //public Vector2 minPosition;
    public Transform maxPositionX;
    public Transform maxPositionY;
    public Transform minPositionX;
    public Transform minPositionY;

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPositionX.position.x, maxPositionX.position.x);

            targetPosition.y = Mathf.Clamp(targetPosition.y, minPositionY.position.y, maxPositionY.position.y);

            transform.position = Vector2.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
