using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWallCheck : MonoBehaviour
{
    public GuardData guard;
    private bool isJumping = false;
    public float jumpForce = 5.0f;
    public Transform guardPosition;
    public Rigidbody2D rb;
    public EnemyController enemyController;

    private void Update()
    {
        if (guard.facingSide == GuardData.FacingSide.left)
        {
            transform.position = new Vector3(guardPosition.position.x - 0.6f, guardPosition.position.y, guardPosition.position.z);
        }
        else
        {
            transform.position = new Vector3(guardPosition.position.x + 0.6f, guardPosition.position.y, guardPosition.position.z);
        }
    }

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
