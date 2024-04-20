using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public enum FacingSide { left, right }
    public enum PlayerMovementState { idle, walking, running, crouching, jumping, falling }
    public enum PlayerNoise { none, mid, loud }
    public FacingSide facingSide = FacingSide.right;
    public PlayerMovementState state = PlayerMovementState.idle;
    public int itemSelectedPosition = 0;
}
