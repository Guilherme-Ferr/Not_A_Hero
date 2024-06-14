using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private PlayerData player;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerData>();
    }

    void Update()
    {
        if (!player.dead)
        {
            UpdateAnimationState();
            FlipSpriteSide();
        }
    }

    private void UpdateAnimationState()
    {
        anim.SetInteger("state", (int)player.state);
    }

    private void FlipSpriteSide()
    {
        if (player.state != PlayerData.PlayerMovementState.shootingSlingshot ||
        player.state != PlayerData.PlayerMovementState.shootingSlingshotTorch ||
        player.state != PlayerData.PlayerMovementState.climbingBridge)
        {
            sprite.flipX = player.facingSide == PlayerData.FacingSide.left;
        }
    }
}
