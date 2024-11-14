using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GuardData data;
    public Transform player;
    public float speed = 2.5f;
    public float hearingRange = 2.0f;
    private bool isGrounded = false;
    public PlayerSound playerSound;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // FollowPlayer();
        SeekPlayer();
        ControllState();
        FlipSpriteSide();
        Sentinel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PrisonFloor"))
        {
            // Debug.Log("é dento11");
            isGrounded = true;
        }

        // if(collision.gameObject.CompareTag("GuardLimits"))
        // {
        //     Debug.Log("é dento");
        // }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PrisonFloor"))
        {
            // Debug.Log("é fora222");
            isGrounded = false;
        }
        
        // if(collision.gameObject.CompareTag("GuardLimits"))
        // {
        //     Debug.Log("é fora");
        // }
    }

    // void OnCollisionStay2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("GuardLimits"))
    //     {
    //         Debug.Log("é dento333333");
    //     }
    // }

    // void FollowPlayer()
    // {
    //     float distanceToPlayer = Vector2.Distance(transform.position, player.position);
    //     if (distanceToPlayer <= hearingRange)
    //     {
    //         Debug.Log("verificando som");
    //         VerifyPlayerSound();
    //     }
    // }

    // void VerifyPlayerSound()
    // {
    //     if (playerSound.playerNoise == PlayerSound.PlayerNoise.mid || playerSound.playerNoise == PlayerSound.PlayerNoise.loud)
    //     {
    //         Debug.Log("correndo atras");
    //         SeekPlayer();
    //     }
    // }

    void Sentinel(){
        if(!data.aggro && !data.isSleepyGuard){
            
        }
    }

    void SeekPlayer()
    {
        if (data.aggro)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
    }

    private void FlipSpriteSide()
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

    void ControllState()
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