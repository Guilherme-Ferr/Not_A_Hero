using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GuardData data;
    public Transform player;
    public PlayerData playerData;
    public float speed = 2.5f;
    private bool isGrounded = false;
    public bool playerInActionArea = false;
    public PlayerSound playerSound;

    private Rigidbody2D rb;




    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool movingRight = true; // Controle de direção

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SeekPlayer();
        ControllState();
        FlipSpriteSide();
        Patrol();
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
        if (data.state == GuardData.GuardMovementState.idle && !playerInActionArea)
        {
            Debug.Log("anda de um lado para o outro");


            // if (movingRight)
            // {
            //     rb.velocity = new Vector2(2f, rb.velocity.y);

            //     if (transform.position.x >= endPoint.x)
            //     {
            //         movingRight = false; // Inverte a direção
            //     }
            // }
            // else
            // {
            //     rb.velocity = new Vector2(-2f, rb.velocity.y);

            //     if (transform.position.x <= startPoint.x)
            //     {
            //         movingRight = true; // Inverte a direção
            //     }
            // }
        }
    }

    void SeekPlayer()
    {
        if (data.aggro && playerInActionArea && !playerData.isHiden)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
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
            }
            else if (rb.velocity.y < -0.01f && !isGrounded)
            {
                data.state = GuardData.GuardMovementState.falling;
            }
            else if (Mathf.Abs(rb.velocity.x) > 0.01f)
            {
                data.state = GuardData.GuardMovementState.running;
            }
            else
            {
                data.state = GuardData.GuardMovementState.idle;
            }
        }
    }
}