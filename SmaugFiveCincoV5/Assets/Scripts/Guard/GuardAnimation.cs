using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private GuardData guard;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        guard = GetComponent<GuardData>();
    }

    void Update()
    {
        UpdateAnimationState();
        FlipSpriteSide();
    }

    private void UpdateAnimationState()
    {
        anim.SetInteger("state", (int)guard.state);
    }

    private void FlipSpriteSide()
    {
        if (guard.aggro)
        {
            sprite.flipX = guard.facingSide == GuardData.FacingSide.left;
        }
    }
}
