using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectKey : MonoBehaviour
{
    public AudioSource keyCollectSoundEffect;
    public TextMeshProUGUI objectiveTextMesh;
    private bool alreadyCollected = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (!alreadyCollected)
            {
                PlayerData player = collider.gameObject.GetComponent<PlayerData>();
                player.collectedKey = true;
                keyCollectSoundEffect.Play();
                objectiveTextMesh.text = "Volte para a saida do andar.";
                alreadyCollected = true;
            }
        }
    }
}
