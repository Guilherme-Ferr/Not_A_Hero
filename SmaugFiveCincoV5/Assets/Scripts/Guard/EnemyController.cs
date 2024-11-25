using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GuardData data;
    public Transform player;
    public PlayerData playerData;
    public float speed = 3.7f;
    private bool isGrounded = false;
    public bool playerInActionArea = false;
    public PlayerSound playerSound;
    private Rigidbody2D rb;
    public bool movingRight = true;
    public float jumpForce = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SeekPlayer();
        ControllState();
        FlipSpriteSide();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PrisonFloor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PrisonFloor"))
        {
            isGrounded = false;
        }
    }

    void Patrol()
    {
        if (!data.aggro || !playerInActionArea)
        {
            data.state = GuardData.GuardMovementState.running;
            speed = 2f;

            if (movingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                data.facingSide = GuardData.FacingSide.right;
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                data.facingSide = GuardData.FacingSide.left;
            }
        }
        else
        {
            data.state = GuardData.GuardMovementState.idle;
        }
    }

    void SeekPlayer()
    {
        if (data.aggro && playerInActionArea && !playerData.isHiden)
        {
            speed = 3.7f;
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        else
        {
            if (rb.bodyType != RigidbodyType2D.Static)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void FlipSpriteSide()
    {
        if (data.aggro && playerInActionArea)
        {
            if (player.position.x < transform.position.x)
            {
                data.facingSide = GuardData.FacingSide.left;
            }
            else
            {
                data.facingSide = GuardData.FacingSide.right;
            }
        }
    }

    void ControllState()
    {
        if (data.state != GuardData.GuardMovementState.sleeping)
        {
            if (rb.velocity.y > 0.01f)
            {
                data.state = GuardData.GuardMovementState.jumping;
                if (movingRight)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
            else if (rb.velocity.y < -0.01f && !isGrounded)
            {
                data.state = GuardData.GuardMovementState.falling;
                if (movingRight)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed * 1.1f, rb.velocity.y);
                }
            }
            else if (Mathf.Abs(rb.velocity.x) > 0.01f)
            {
                data.state = GuardData.GuardMovementState.running;
            }
            else
            {
                Patrol();
            }
        }
    }
}