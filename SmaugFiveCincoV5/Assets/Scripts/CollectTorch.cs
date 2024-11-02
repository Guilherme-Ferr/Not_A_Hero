using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTorch : MonoBehaviour
{
    public Transform torchLight;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            player.collectedTorch = true;
            player.state = PlayerData.PlayerMovementState.idleTorch;
            rb.bodyType = RigidbodyType2D.Dynamic;
            // Destroy(torchLight.gameObject);
            // Destroy(transform.gameObject);

            // SpriteRenderer spriteRenderer1 = torchLight.gameObject.GetComponent<SpriteRenderer>();
            // SpriteRenderer spriteRenderer2 = transform.gameObject.GetComponent<SpriteRenderer>();

            // spriteRenderer2.

            // torchLight.gameObject.SetActive(false);
            // transform.gameObject.SetActive(false);
        }
    }
}
