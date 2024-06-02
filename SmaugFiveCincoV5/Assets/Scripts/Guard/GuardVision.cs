using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public GuardData guard;

    private void Update()
    {
        FlipSpriteSide();
    }

    private void FlipSpriteSide()
    {
        if (guard.facingSide == GuardData.FacingSide.left)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guard.canSeePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guard.canSeePlayer = false;
        }
    }

}