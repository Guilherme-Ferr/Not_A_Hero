using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public Transform guard;
    public GuardData guardData;

    private void Update()
    {
        //     FlipSpriteSide();
        // }

        // private void FlipSpriteSide()
        // {
        //     float positionY = (float)(guard.position.y + 0.5);
        //     transform.position = guardData.facingSide == GuardData.FacingSide.left ?
        //     new Vector2((float)(guard.position.x - 4), positionY) :
        //     new Vector2((float)(guard.position.x + 4), positionY);
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         // guardData.canSeePlayer = true;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         // guardData.canSeePlayer = false;
    //     }
    // }

}