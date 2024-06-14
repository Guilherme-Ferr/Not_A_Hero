using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float climbSpeed = 2f;
    private bool isTouchingLadder;
    private bool isClimbing;
    private Animator animator; // Referência ao Animator
    private Rigidbody2D rb;

    [SerializeField] public PlayerData player;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if (isTouchingLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            animator.speed = 1;
            player.state = player.withTorch ? PlayerData.PlayerMovementState.climbingTorch : PlayerData.PlayerMovementState.climbing;
        }
        else if (isTouchingLadder)
        {
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isTouchingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isTouchingLadder = false;
            isClimbing = false;
            player.state = player.withTorch ? PlayerData.PlayerMovementState.idleTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.idleSlingshot : PlayerData.PlayerMovementState.idle;
        }
    }
}
