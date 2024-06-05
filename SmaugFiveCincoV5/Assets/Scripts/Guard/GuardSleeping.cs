using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSleeping : MonoBehaviour
{
    [SerializeField] public GuardData guard;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private bool wokeUp = false;

    private void Start()
    {
        if (guard.isSleepyGuard)
        {
            coll = GetComponent<BoxCollider2D>();
            coll.isTrigger = true;
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = true;
            guard.state = GuardData.GuardMovementState.sleeping;
        }
    }

    private void Update()
    {
        if (guard.isSleepyGuard && guard.aggro && !wokeUp)
        {
            wokeUp = true;
            coll.isTrigger = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            guard.state = GuardData.GuardMovementState.running;
        }
    }
}
