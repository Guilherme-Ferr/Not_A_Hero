using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTorch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            player.withTorch = true;
            player.state = PlayerData.PlayerMovementState.idleTorch;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
