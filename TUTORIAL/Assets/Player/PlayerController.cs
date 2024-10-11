using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(CollisionTouchCheck))] // OBLIGATORY COMPONENTS
public class PlayerController : MonoBehaviour
{
    // moveSpeed float
    // rigidbody2d.velocity
    [SerializeField]
    float moveSpeed = 100;
    Rigidbody2D rb;
    CollisionTouchCheck colTouchCheck;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colTouchCheck = GetComponent<CollisionTouchCheck>();
    }

    Vector2 moveInput;
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        //moveInput processing
        rb.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public float jumpImpulse = 20;
    public void OnJump(InputAction.CallbackContext context)
    {
        // if (context.started)
        // {
        //     if (colTouchCheck.IsGrounded)
        //     {
        //         rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpImpulse);
        //     }
        // }
        if (colTouchCheck.IsGrounded)
        {
            if(context.started)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpImpulse);
            }
        }
        else
        {
            if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
            }
        }

    }
}
