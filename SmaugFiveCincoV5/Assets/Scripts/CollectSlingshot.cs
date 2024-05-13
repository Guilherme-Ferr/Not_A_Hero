using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSlingshot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();
            player.collectedSlingshot = true;
        }
    }
}
