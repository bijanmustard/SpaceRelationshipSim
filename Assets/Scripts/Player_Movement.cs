using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;


    Vector2 movement;

    private Vector2 lookDirection;
    private Vector2 prevLookDirection;




    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);



        if (movement.x != 0 || movement.y != 0)
        {

            lookDirection = movement.normalized;
            prevLookDirection = lookDirection;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;



        }
        else
        {
            float angle = Mathf.Atan2(prevLookDirection.y, prevLookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

        }






    }
}
