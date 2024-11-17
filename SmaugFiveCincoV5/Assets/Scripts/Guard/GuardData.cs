using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardData : MonoBehaviour
{
    public enum FacingSide { left, right }
    public enum GuardMovementState
    {
        idle,
        running,
        jumping,
        falling,
        attacking,
        sleeping
    }
    public FacingSide facingSide = FacingSide.right;
    public GuardMovementState state = GuardMovementState.idle;
    public bool aggro = false;
    public bool isSleepyGuard;
}
