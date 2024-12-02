using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectKey : MonoBehaviour
{
    public AudioSource keyCollectSoundEffect;
    public TextMeshProUGUI objectiveTextMesh;
    public KeyCounter keyCounter;
    private bool alreadyCollected = false;
    private PlayerData player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (!alreadyCollected)
            {
                player = collider.gameObject.GetComponent<PlayerData>();
                player.collectedKey = true;
                keyCollectSoundEffect.Play();
                objectiveTextMesh.text = "Volte para a saida do andar.";
                alreadyCollected = true;
                // keyCounter.keys++;
            }
        }
    }

    void Update()
    {
        keyCounter.keys = player.collectedKey ? 1 : 0;
    }
}
