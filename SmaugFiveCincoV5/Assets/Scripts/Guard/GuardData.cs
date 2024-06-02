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
    }
    public FacingSide facingSide = FacingSide.right;
    public GuardMovementState state = GuardMovementState.running;
    public bool dead = false;
}
