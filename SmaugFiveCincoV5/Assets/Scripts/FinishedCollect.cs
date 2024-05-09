using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedCollect : MonoBehaviour
{
    [SerializeField] public CollectVegetables collectVegetable;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && collectVegetable.finishedCollecting)
        {
            Debug.Log("pode al mossa");
        }
    }
}
