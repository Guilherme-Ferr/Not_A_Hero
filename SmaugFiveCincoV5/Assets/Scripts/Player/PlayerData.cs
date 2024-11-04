using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public CollectTorch collectTorch;
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
        carryingObject,
    }
    public FacingSide facingSide = FacingSide.right;
    public PlayerMovementState state = PlayerMovementState.idle;
    public int itemSelectedPosition = 0;
    public bool collectedSlingshot = false;
    public bool collectedTorch = false;
    public bool collectedKey = false;
    public bool withTorch = false;
    public bool isInWaterfall = false;
    public bool dead = false;

    public bool collectedSlingshotState;
    public bool collectedTorchState;
    public bool collectedKeyState;
    public Vector3 savedPosition;

    public void SaveState(PlayerData state)
    {
        collectedSlingshotState = state.collectedSlingshot;
        collectedTorchState = state.collectedTorch;
        collectedKeyState = state.collectedKey;
        savedPosition = state.transform.position;
    }

    public void SetState()
    {
        collectedSlingshot = collectedSlingshotState;
        collectedTorch = collectedTorchState;
        collectedKey = collectedKeyState;
        withTorch = false;
        dead = false;
        transform.position = savedPosition;
        collectTorch.resetTorch();
    }
}
