using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    private PlayerMovement player;

    public Transform target;
    // public Transform groundCheck;  // Referência ao objeto GroundCheck
    public LayerMask groundLayer;  // Assign this in the Inspector to the "Ground" layer
    // public float checkRadius = 0.1f;  // Raio do círculo de verificação
    private bool isGrounded;

    private void Start()
    {
        player = target.gameObject.GetComponent<PlayerMovement>();
        // coll = GetComponent<BoxCollider2D>();
        // coll = target.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        // CheckIfGrounded();
        transform.position = new Vector2(target.position.x, (float)(target.position.y - 1));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsTouchingGround(collision))
        {
            isGrounded = true;
            player.isGrounded = true;
            Debug.Log("Touching the ground.");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (IsTouchingGround(collision))
        {
            isGrounded = false;
            player.isGrounded = false;
            Debug.Log("Not touching the ground.");
        }
    }

    private bool IsTouchingGround(Collider2D collision)
    {
        return (groundLayer & (1 << collision.gameObject.layer)) != 0;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    // void CheckIfGrounded()
    // {
    //     // Verifica se o GroundCheck está colidindo com algo na camada groundLayer
    //     isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    //     if (isGrounded)
    //     {
    //         player.isJumping = false;
    //         Debug.Log("O personagem está encostando no tileset do chão.");
    //     }
    //     else
    //     {
    //         player.isJumping = true;
    //         Debug.Log("O personagem não está encostando no tileset do chão.");
    //     }
    // }
    //     private bool isGrounded;
    //     private BoxCollider2D coll;
    //     private PlayerMovement player;
    //     public Transform target;
    //     public LayerMask tilesetLayer;

    //     private void Start()
    //     {
    //         player = target.gameObject.GetComponent<PlayerMovement>();
    //         // coll = GetComponent<BoxCollider2D>();
    //         // coll = target.GetComponent<BoxCollider2D>();
    //     }

    //     private void Update()
    //     {
    //         // if (IsTouchingTileset())
    //         // {
    //         //     player.isJumping = false;
    //         // }
    //         // else
    //         // {
    //         //     player.isJumping = true;
    //         // }
    //         transform.position = new Vector2(target.position.x, (float)(target.position.y - 1));
    //     }


    // private bool IsTouchingTileset()
    // {
    //     float distanceToCheck = 0.1f; // Distância pequena para verificar proximidade
    //     Vector2 direction = Vector2.down; // Direção do raycast (para baixo)

    //     // Realiza um raycast do centro do personagem para a direção especificada
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distanceToCheck, tilesetLayer);

    //     // Se o raycast colidir com algo na camada do tileset, retorna true
    //     return hit.collider != null;
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("1 " + collision.gameObject.tag);
    //     if (collision.gameObject.CompareTag("PrisonFloor"))
    //     {
    //         player.isJumping = false;
    //     }
    // }


    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     Debug.Log("2 " + collision.gameObject.tag);
    //     if (collision.gameObject.CompareTag("PrisonFloor"))
    //     {
    //         player.isJumping = true;
    //     }
    // }

}
