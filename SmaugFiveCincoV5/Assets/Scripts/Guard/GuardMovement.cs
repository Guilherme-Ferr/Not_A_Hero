using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private float moveSpeed = 2.5f;
    public CapsuleCollider2D groundCheck;
    public LayerMask groundLayer;
    public GuardData guard;
    public float followRange = 2.0f;

    private void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
    }

    // private void Update()
    // {
    //     // MoveGuard();
    //     // IsGrounded();
    //     float distanceToPlayer = Vector2.Distance(transform.position, target.position);
    //     if (distanceToPlayer <= followRange)
    //     {
    //         FollowPlayer();
    //     }
    // }

    // void FollowPlayer()
    // {
    //     Vector2 direction = (target.position - transform.position).normalized;
    //     rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    // }

    public void JumpGuard()
    {
        // if (IsGrounded() && guard.aggro)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, 6f);
        // }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCapsule(groundCheck.transform.position, groundCheck.size, groundCheck.direction, 0, groundLayer);
        // if (isGrounded && guard.state == GuardData.GuardMovementState.falling)
        // {
        //     guard.state = GuardData.GuardMovementState.landing;
        // }
        return isGrounded;
    }

    private void MoveGuard()
    {
        // if (guard.aggro)
        // {
        //     float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        //     if (distanceToPlayer <= followRange || distanceToPlayer >= followRange)
        //     {
        //         Vector2 direction = (target.position - transform.position).normalized;
        //         rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        //     }
        // }











        //     if (guard.aggro)
        //     {
        //         // Player na esquerda
        //         if (target.position.x < transform.position.x - 1.5f)
        //         {
        //             // if (rb.velocity.y > .1f)
        //             // {
        //             //     guard.state = GuardData.GuardMovementState.jumping;
        //             // }
        //             // else if (rb.velocity.y < -.1f)
        //             // {
        //             //     guard.state = GuardData.GuardMovementState.falling;
        //             // }
        //             // else
        //             // {
        //             //     // if (guard.state != GuardData.GuardMovementState.landing)
        //             //     // {
        //             //     guard.state = GuardData.GuardMovementState.running;
        //             //     // }
        //             // }
        //             rb.bodyType = RigidbodyType2D.Dynamic;
        //             rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        //             guard.facingSide = GuardData.FacingSide.left;
        //         }
        //         // Player na direita
        //         else if (target.position.x > transform.position.x + 1.5f)
        //         {
        //             // if (rb.velocity.y > .1f)
        //             // {
        //             //     guard.state = GuardData.GuardMovementState.jumping;
        //             // }
        //             // else if (rb.velocity.y < -.1f)
        //             // {
        //             //     guard.state = GuardData.GuardMovementState.falling;
        //             // }
        //             // else
        //             // {
        //             //     // if (guard.state != GuardData.GuardMovementState.landing)
        //             //     // {
        //             //     guard.state = GuardData.GuardMovementState.running;
        //             //     // }
        //             // }
        //             rb.bodyType = RigidbodyType2D.Dynamic;
        //             rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        //             guard.facingSide = GuardData.FacingSide.right;
        //         }
        //     }
    }
}
