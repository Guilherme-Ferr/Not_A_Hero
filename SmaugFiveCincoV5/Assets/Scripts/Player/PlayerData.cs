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
    }
    public FacingSide facingSide = FacingSide.right;
    public PlayerMovementState state = PlayerMovementState.idle;
    public int itemSelectedPosition = 0;
    public bool collectedSlingshot = false;
    public bool dead = false;
}
