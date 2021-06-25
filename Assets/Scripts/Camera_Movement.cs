using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y);

            transform.position = Vector2.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
