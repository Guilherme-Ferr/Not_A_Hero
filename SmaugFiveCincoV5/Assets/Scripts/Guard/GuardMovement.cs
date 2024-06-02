using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float moveSpeed = 3.75f;

    [SerializeField] public GuardData guard;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Player na esquerda
        if (target.position.x < transform.position.x - 1.5f)
        {
            guard.state = GuardData.GuardMovementState.running;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            guard.facingSide = GuardData.FacingSide.left;
        }
        // Player na direita
        else if (target.position.x > transform.position.x + 1.5f)
        {
            guard.state = GuardData.GuardMovementState.running;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            guard.facingSide = GuardData.FacingSide.right;
        }
    }
}
