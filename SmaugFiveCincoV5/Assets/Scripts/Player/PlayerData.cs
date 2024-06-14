using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public enum FacingSide { left, right }
    public enum PlayerMovementState
    {
        idle,
        walking,
        running,
        crouching,
        jumping,
        falling,
        climbing,
        idleSlingshot,
        walkingSlingshot,
        runningSlingshot,
        jumpingSlingshot,
        landing,
        landingSlingshot,
        fallingSlingshot,
        shootingSlingshot,
        climbingBridge,
        dropingBridge,
        idleTorch,
        walkingTorch,
        runningTorch,
        crouchingTorch,
        jumpingTorch,
        fallingTorch,
        climbingTorch,
        landingTorch,
        shootingSlingshotTorch,
    }
    public FacingSide facingSide = FacingSide.right;
    public PlayerMovementState state = PlayerMovementState.idle;
    public int itemSelectedPosition = 0;
    public bool collectedSlingshot = false;
    public bool collectedTorch = false;
    public bool withTorch = false;
    public bool dead = false;
}
