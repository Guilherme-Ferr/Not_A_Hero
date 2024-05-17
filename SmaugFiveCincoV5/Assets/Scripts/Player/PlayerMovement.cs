using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float dirX = 0f;
    private float runningSpeed = 5f;
    private float walkingSpeed = 3f;
    private float crouchingSpeed = 2f;
    private float jumpForce = 10f;
    public CapsuleCollider2D groundCheck;
    public LayerMask groundLayer;

    [SerializeField] public PlayerData player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.transform.position, groundCheck.size, groundCheck.direction, 0, groundLayer);
    }

    private void MovePlayer()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        float moveSpeed = ControlPlayerSpeed();
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (dirX > 0f)
        {
            player.facingSide = PlayerData.FacingSide.right;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.state = player.collectedSlingshot ? PlayerData.PlayerMovementState.runningSlingshot : PlayerData.PlayerMovementState.running;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    player.state = PlayerData.PlayerMovementState.crouching;
                }
                else
                {
                    player.state = player.collectedSlingshot ? PlayerData.PlayerMovementState.walkingSlingshot : PlayerData.PlayerMovementState.walking;
                }
            }
        }
        else if (dirX < 0f)
        {
            player.facingSide = PlayerData.FacingSide.left;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.state = player.collectedSlingshot ? PlayerData.PlayerMovementState.runningSlingshot : PlayerData.PlayerMovementState.running;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    player.state = PlayerData.PlayerMovementState.crouching;
                }
                else
                {
                    player.state = player.collectedSlingshot ? PlayerData.PlayerMovementState.walkingSlingshot : PlayerData.PlayerMovementState.walking;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                player.state = PlayerData.PlayerMovementState.crouching;
            }
            else
            {
                player.state = player.collectedSlingshot ? PlayerData.PlayerMovementState.idleSlingshot : PlayerData.PlayerMovementState.idle;
            }
        }
    }

    private float ControlPlayerSpeed()
    {
        return player.state switch
        {
            PlayerData.PlayerMovementState.walking or PlayerData.PlayerMovementState.walkingSlingshot => walkingSpeed,
            PlayerData.PlayerMovementState.running or PlayerData.PlayerMovementState.runningSlingshot => runningSpeed,
            PlayerData.PlayerMovementState.crouching => crouchingSpeed,
            _ => 0f,
        };
    }
}
