using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private float moveSpeed = 3.5f;
    public CapsuleCollider2D groundCheck;
    public LayerMask groundLayer;

    [SerializeField] public GuardData guard;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        while (guard.aggro == true)
        {
            MoveGuard();
        }
        IsGrounded();
    }

    public void JumpGuard()
    {
        if (IsGrounded() && guard.aggro)
        {
            rb.velocity = new Vector2(rb.velocity.x, 6f);
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCapsule(groundCheck.transform.position, groundCheck.size, groundCheck.direction, 0, groundLayer);
        if (isGrounded && guard.state == GuardData.GuardMovementState.falling)
        {
            guard.state = GuardData.GuardMovementState.landing;
        }
        return isGrounded;
    }

    private void MoveGuard()
    {
        // Player na esquerda
        if (target.position.x < transform.position.x - 1.5f)
        {
            if (rb.velocity.y > .1f)
            {
                guard.state = GuardData.GuardMovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                guard.state = GuardData.GuardMovementState.falling;
            }
            else
            {
                guard.state = GuardData.GuardMovementState.running;
            }
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            guard.facingSide = GuardData.FacingSide.left;
        }
        // Player na direita
        else if (target.position.x > transform.position.x + 1.5f)
        {
            if (rb.velocity.y > .1f)
            {
                guard.state = GuardData.GuardMovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                guard.state = GuardData.GuardMovementState.falling;
            }
            else
            {
                guard.state = GuardData.GuardMovementState.running;
            }
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            guard.facingSide = GuardData.FacingSide.right;
        }
    }
}
