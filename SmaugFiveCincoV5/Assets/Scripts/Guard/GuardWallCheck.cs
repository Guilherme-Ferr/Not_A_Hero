using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWallCheck : MonoBehaviour
{
    private bool isJumping = false;
    public float jumpForce = 5.0f;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PrisonFloor") && !isJumping)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PrisonFloor"))
        {
            isJumping = false;
        }
    }
}
