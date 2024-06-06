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
        attacking,
        sleeping
    }
    public FacingSide facingSide = FacingSide.right;
    public GuardMovementState state = GuardMovementState.running;
    public bool canHearPlayer = false;
    public bool canSeePlayer = false;
    public bool aggro = false;
    public bool dead = false;
    public bool isSleepyGuard;

    private void Update()
    {

        // if (aggro)
        // {
        //     state = GuardMovementState.idle;
        // }


        //     if (canHearPlayer || canSeePlayer)
        //     {
        //         aggro = true;
        //     }

        //     if (!canHearPlayer && !canSeePlayer)
        //     {
        //         aggro = false;
        //     }
    }
}
