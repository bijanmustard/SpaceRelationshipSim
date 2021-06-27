using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private Animator animator;

    Vector2 movement;

    private Vector2 lookDirection;
    private Vector2 prevLookDirection;

    private bool locked = false;
    private bool canMove = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //Note: This is just to prevent initially spawning at (0,0)

        if (Starting_Position_Value.transitionNumber != 0)
        {
            transform.position = Starting_Position_Value.initialValue;

        }

    }

    void Update()
    {
        if (!locked && canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);



            if (movement.x != 0 || movement.y != 0)
            {

                lookDirection = movement.normalized;
                prevLookDirection = lookDirection;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                animator.SetTrigger("Walk");


            }
            else
            {
                float angle = Mathf.Atan2(prevLookDirection.y, prevLookDirection.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                animator.SetTrigger("Idle");
            }
        }
    }

        //LockMovement is called to lock the player's current move dir
        public void LockMovement(bool b) { locked = b; }

    //ToggleMove is called to toggle canMove.
    public void ToggleMove(bool b) { canMove = b; }

}
