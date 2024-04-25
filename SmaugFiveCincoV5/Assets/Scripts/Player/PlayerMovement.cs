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
    private bool isJumping = false;

    [SerializeField] public PlayerData player;
    [SerializeField] private LayerMask jumpableGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        MovePlayer();
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
                player.state = PlayerData.PlayerMovementState.running;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    player.state = PlayerData.PlayerMovementState.crouching;
                }
                else
                {
                    player.state = PlayerData.PlayerMovementState.walking;
                }
            }
        }
        else if (dirX < 0f)
        {
            player.facingSide = PlayerData.FacingSide.left;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.state = PlayerData.PlayerMovementState.running;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    player.state = PlayerData.PlayerMovementState.crouching;
                }
                else
                {
                    player.state = PlayerData.PlayerMovementState.walking;
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
                player.state = PlayerData.PlayerMovementState.idle;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

    }

    private float ControlPlayerSpeed()
    {
        return player.state switch
        {
            PlayerData.PlayerMovementState.walking => walkingSpeed,
            PlayerData.PlayerMovementState.running => runningSpeed,
            PlayerData.PlayerMovementState.crouching => crouchingSpeed,
            _ => 0f,
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            isJumping = false;
        }
    }
}
