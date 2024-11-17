using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSleeping : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private GuardData guard;
    private bool wokeUp = false;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        guard = GetComponent<GuardData>();
        coll.isTrigger = true;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
        guard.state = GuardData.GuardMovementState.sleeping;
    }

    private void Update()
    {
        if (guard.aggro && !wokeUp)
        {
            wokeUp = true;
            coll.isTrigger = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            guard.state = GuardData.GuardMovementState.running;
        }
    }
}
