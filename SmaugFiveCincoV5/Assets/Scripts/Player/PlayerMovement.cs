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
    public bool isJumping = false;
    public LayerMask tilesetLayer;
    public LayerMask groundLayer;  // Assign this in the Inspector to the "Ground" layer


    // public Transform groundCheck;  // Referência ao objeto GroundCheck
    public float checkRadius = 0.1f;  // Raio do círculo de verificação

    public bool isGrounded;

    [SerializeField] public PlayerData player;
    [SerializeField] private LayerMask jumpableGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // private void Update()
    // {

    // }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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

    void Update()
    {
        // Debug.Log(isJumping);
        MovePlayer();
        // IsGrounded();
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsTouchingGround(collision))
        {
            isGrounded = true;
            Debug.Log("Touching the ground.");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (IsTouchingGround(collision))
        {
            isGrounded = false;
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


    // bool IsTouchingTileset()
    // {
    //     float distanceToCheck = 0.1f; // Distância pequena para verificar proximidade
    //     Vector2 direction = Vector2.down; // Direção do raycast (para baixo)

    //     // Realiza um raycast do centro do personagem para a direção especificada
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distanceToCheck, tilesetLayer);

    //     // Se o raycast colidir com algo na camada do tileset, retorna true
    //     return hit.collider != null;
    // }


    // private bool IsTouchingTileset()
    // {
    //     float distanceToCheck = 1f; // Distância pequena para verificar proximidade
    //     Vector2 direction = Vector2.down; // Direção do raycast (para baixo)

    //     // Realiza um raycast do centro do personagem para a direção especificada
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distanceToCheck, tilesetLayer);

    //     // Se o raycast colidir com algo na camada do tileset, retorna true
    //     return hit.collider != null;
    // }

    //     void CheckIfGrounded()
    // {
    //     // Verifica se o GroundCheck está colidindo com algo na camada groundLayer
    //     isGrounded = Physics2D.OverlapCircle(transform.position, checkRadius, groundLayer);

    //     if (isGrounded)
    //     {
    //         Debug.Log("O personagem está encostando no tileset do chão.");
    //     }
    //     else
    //     {
    //         Debug.Log("O personagem não está encostando no tileset do chão.");
    //     }
    // }

}
