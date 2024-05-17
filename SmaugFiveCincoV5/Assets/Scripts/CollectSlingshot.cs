using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSlingshot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerData player = collider.gameObject.GetComponent<PlayerData>();
            player.collectedSlingshot = true;
            spriteRenderer.sprite = null;
        }
    }
}
