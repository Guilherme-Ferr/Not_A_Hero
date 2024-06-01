using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingBridge : MonoBehaviour
{
    private bool canClimb = true;
    private float groundPositionX;
    private float groundPositionY;
    private Rigidbody2D rb;
    [SerializeField] public PlayerData player;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClimbBridge"))
        {
            if (canClimb && (player.state != PlayerData.PlayerMovementState.climbingBridge || player.state != PlayerData.PlayerMovementState.idle))
            {
                ClimbBridge();
                Destroy(collision.gameObject);
            }
        }
    }

    private void ClimbBridge()
    {
        canClimb = false;

        rb.bodyType = RigidbodyType2D.Static;
        rb.gravityScale = 0;

        player.state = PlayerData.PlayerMovementState.idle;

        player.state = PlayerData.PlayerMovementState.climbingBridge;

        // Pega a posição atual do GameObject
        Vector3 currentPosition = transform.position;
        groundPositionX = currentPosition.x;
        groundPositionY = currentPosition.y;

        // Define a nova posição
        transform.position = new Vector3(currentPosition.x, -0.25f, currentPosition.z);

    }

    public void DropBridge()
    {
        player.state = PlayerData.PlayerMovementState.dropingBridge;
    }

    public void BackToMove()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1;
        player.state = PlayerData.PlayerMovementState.idle;
        transform.position = new Vector3(groundPositionX, groundPositionY, 0f);
    }
}
