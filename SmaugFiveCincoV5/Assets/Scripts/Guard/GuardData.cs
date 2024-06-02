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
        landing,
        attacking
    }
    public FacingSide facingSide = FacingSide.right;
    public GuardMovementState state = GuardMovementState.running;
    public bool canHearPlayer = false;
    public bool canSeePlayer = false;
    public bool aggro = false;
    public bool dead = false;

    private void Update()
    {
        if (canHearPlayer || canSeePlayer)
        {
            aggro = true;
        }

        if (!canHearPlayer && !canSeePlayer)
        {
            aggro = false;
        }
    }
}
