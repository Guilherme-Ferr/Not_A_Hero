using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWallCheck : MonoBehaviour
{
    private bool isJumping = false;
    public GuardMovement guardMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PrisonFloor") && !isJumping)
        {
            isJumping = true;
            guardMovement.JumpGuard();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PrisonFloor"))
        {
            isJumping = false;
        }
    }
}
