using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public bool isPaused;
    private float dirX = 0f;
    private float runningSpeed = 4f;
    private float walkingSpeed = 3f;
    private float crouchingSpeed = 2f;
    private float jumpForce = 12f;
    public float maxFallSpeed = -10f;
    public CapsuleCollider2D groundCheck;
    public LayerMask groundLayer;

    [SerializeField] public PlayerData player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!player.dead)
        {
            MovePlayer();
            JumpPlayer();
        }
    }

    private void FixedUpdate()
    {
        // Limitar a velocidade de queda
        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && player.collectedSlingshot &&
        player.state != PlayerData.PlayerMovementState.dropingBridge &&
        player.state != PlayerData.PlayerMovementState.climbingBridge &&
        player.state != PlayerData.PlayerMovementState.climbing &&
        player.state != PlayerData.PlayerMovementState.shootingSlingshot &&
        player.state != PlayerData.PlayerMovementState.shootingSlingshotTorch
        )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCapsule(groundCheck.transform.position, groundCheck.size, groundCheck.direction, 0, groundLayer);
        if (isGrounded && (player.state == PlayerData.PlayerMovementState.falling ||
        player.state == PlayerData.PlayerMovementState.fallingSlingshot ||
        player.state == PlayerData.PlayerMovementState.fallingTorch))
        {
            player.state = player.withTorch ? PlayerData.PlayerMovementState.landingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.landingSlingshot : PlayerData.PlayerMovementState.landing;
        }
        return isGrounded;
    }

    private void MovePlayer()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        float moveSpeed = ControlPlayerSpeed();
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (player.state != PlayerData.PlayerMovementState.climbingBridge)
        {
            if (dirX > 0f)
            {
                if (player.state != PlayerData.PlayerMovementState.shootingSlingshot && player.state != PlayerData.PlayerMovementState.shootingSlingshotTorch)
                {
                    player.facingSide = PlayerData.FacingSide.right;
                }
                if (IsGrounded() && player.state != PlayerData.PlayerMovementState.climbing &&
                player.state != PlayerData.PlayerMovementState.landing &&
                player.state != PlayerData.PlayerMovementState.landingSlingshot &&
                player.state != PlayerData.PlayerMovementState.landingTorch)
                {
                    if (Input.GetKey(KeyCode.LeftShift) && player.collectedSlingshot)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.runningTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.runningSlingshot : PlayerData.PlayerMovementState.running;
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftControl) && player.collectedSlingshot)
                        {
                            player.state = player.withTorch ? PlayerData.PlayerMovementState.crouchingTorch : PlayerData.PlayerMovementState.crouching;
                        }
                        else
                        {
                            player.state = player.withTorch ? PlayerData.PlayerMovementState.walkingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.walkingSlingshot : PlayerData.PlayerMovementState.walking;
                        }
                    }
                }
                else
                {
                    if (rb.velocity.y > .1f && player.state != PlayerData.PlayerMovementState.climbing)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.jumpingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.jumpingSlingshot : PlayerData.PlayerMovementState.jumping;
                    }
                    else if (rb.velocity.y < -.1f && player.state != PlayerData.PlayerMovementState.climbing)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.fallingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.fallingSlingshot : PlayerData.PlayerMovementState.falling;
                    }
                }
            }
            else if (dirX < 0f)
            {
                if (player.state != PlayerData.PlayerMovementState.shootingSlingshot && player.state != PlayerData.PlayerMovementState.shootingSlingshotTorch)
                {
                    player.facingSide = PlayerData.FacingSide.left;
                }
                if (IsGrounded() && player.state != PlayerData.PlayerMovementState.climbing &&
                player.state != PlayerData.PlayerMovementState.landing &&
                player.state != PlayerData.PlayerMovementState.landingSlingshot &&
                player.state != PlayerData.PlayerMovementState.landingTorch)
                {
                    if (Input.GetKey(KeyCode.LeftShift) && player.collectedSlingshot)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.runningTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.runningSlingshot : PlayerData.PlayerMovementState.running;
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftControl) && player.collectedSlingshot)
                        {
                            player.state = player.withTorch ? PlayerData.PlayerMovementState.crouchingTorch : PlayerData.PlayerMovementState.crouching;
                        }
                        else
                        {
                            player.state = player.withTorch ? PlayerData.PlayerMovementState.walkingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.walkingSlingshot : PlayerData.PlayerMovementState.walking;
                        }
                    }
                }
                else
                {
                    if (rb.velocity.y > .1f && player.state != PlayerData.PlayerMovementState.climbing)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.jumpingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.jumpingSlingshot : PlayerData.PlayerMovementState.jumping;
                    }
                    else if (rb.velocity.y < -.1f && player.state != PlayerData.PlayerMovementState.climbing)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.fallingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.fallingSlingshot : PlayerData.PlayerMovementState.falling;
                    }
                }
            }
            else
            {
                if (IsGrounded() && player.state != PlayerData.PlayerMovementState.climbing &&
                player.state != PlayerData.PlayerMovementState.landing &&
                player.state != PlayerData.PlayerMovementState.landingSlingshot &&
                player.state != PlayerData.PlayerMovementState.landingTorch &&
                player.state != PlayerData.PlayerMovementState.shootingSlingshot &&
                player.state != PlayerData.PlayerMovementState.shootingSlingshotTorch)
                {
                    SetIdle();
                }
                else
                {
                    if (rb.velocity.y > .1f && player.state != PlayerData.PlayerMovementState.climbing)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.jumpingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.jumpingSlingshot : PlayerData.PlayerMovementState.jumping;
                    }
                    else if (rb.velocity.y < -.1f && player.state != PlayerData.PlayerMovementState.climbing)
                    {
                        player.state = player.withTorch ? PlayerData.PlayerMovementState.fallingTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.fallingSlingshot : PlayerData.PlayerMovementState.falling;
                    }
                }
            }
        }
    }

    public void SetIdle()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        player.state = player.withTorch ? PlayerData.PlayerMovementState.idleTorch : player.collectedSlingshot ? PlayerData.PlayerMovementState.idleSlingshot : PlayerData.PlayerMovementState.idle;
    }

    private float ControlPlayerSpeed()
    {
        return player.state switch
        {
            PlayerData.PlayerMovementState.walking or
            PlayerData.PlayerMovementState.landing or
            PlayerData.PlayerMovementState.climbing or
            PlayerData.PlayerMovementState.landingSlingshot or
            PlayerData.PlayerMovementState.walkingSlingshot or
            PlayerData.PlayerMovementState.walkingTorch or
            PlayerData.PlayerMovementState.landingTorch => walkingSpeed,
            PlayerData.PlayerMovementState.running or
            PlayerData.PlayerMovementState.jumping or
            PlayerData.PlayerMovementState.falling or
            PlayerData.PlayerMovementState.fallingSlingshot or
            PlayerData.PlayerMovementState.jumpingSlingshot or
            PlayerData.PlayerMovementState.runningSlingshot or
            PlayerData.PlayerMovementState.fallingTorch or
            PlayerData.PlayerMovementState.jumpingTorch or
            PlayerData.PlayerMovementState.runningTorch => runningSpeed,
            PlayerData.PlayerMovementState.crouching or
            PlayerData.PlayerMovementState.crouchingTorch => crouchingSpeed,
            _ => 0f,
        };
    }
}
