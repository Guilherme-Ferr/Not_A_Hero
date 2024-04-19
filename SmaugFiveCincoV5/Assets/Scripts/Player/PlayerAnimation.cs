using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] public PlayerData player;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateAnimationState();
        FlipSpriteSide();
    }

    private void UpdateAnimationState()
    {
        anim.SetInteger("state", (int)player.state);
    }

    private void FlipSpriteSide()
    {
        sprite.flipX = player.facingSide == PlayerData.FacingSide.left;
    }
}
