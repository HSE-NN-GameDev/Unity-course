using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTouchCheck : MonoBehaviour
{
    bool _isGrounded;
    BoxCollider2D collision;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            _isGrounded = value;
            //animation stATE change
        }
    }
    
    void Awake()
    {
        collision = GetComponent<BoxCollider2D>();
    }

    [SerializeField]
    ContactFilter2D groundFilter;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    float groundCheckDistance = 0.05f;
    void FixedUpdate()
    {
        // Is grounded monitoring
        IsGrounded = collision.Cast(Vector2.down, groundFilter, groundHits, groundCheckDistance) > 0;
        
    }
}
