using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSlingshot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public AudioSource keyCollectSoundEffect;
    private bool alreadyCollected = false;
    public Slingshot slingshot;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            slingshot.pedras = 5;
            if (!alreadyCollected)
            {
                PlayerData player = collider.gameObject.GetComponent<PlayerData>();
                player.collectedSlingshot = true;
                spriteRenderer.sprite = null;
                keyCollectSoundEffect.Play();
                alreadyCollected = true;
            }
        }
    }
}
