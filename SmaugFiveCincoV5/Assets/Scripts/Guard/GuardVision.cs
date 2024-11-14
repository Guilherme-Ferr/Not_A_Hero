using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public GuardData guard;
    public Transform guardPosition;

    private void Update()
    {
        if (guard.facingSide == GuardData.FacingSide.left)
        {
            transform.position = new Vector3(guardPosition.position.x -3, guardPosition.position.y, guardPosition.position.z);
        }
        else
        {
            transform.position = new Vector3(guardPosition.position.x + 3, guardPosition.position.y, guardPosition.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guard.aggro = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guard.aggro = false;
        }
    }

}