using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public GuardData guard;

    private void Update()
    {
        if (guard.facingSide == GuardData.FacingSide.left)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // guard.canSeePlayer = true;
            guard.aggro = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // guardData.canSeePlayer = false;
            guard.aggro = false;
        }
    }

}