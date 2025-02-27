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
            player = collider.gameObject.GetComponent<PlayerData>();
            player.collectedKey = true;
            keyCollectSoundEffect.Play();
            objectiveTextMesh.text = "Volte para a saida do andar.";
            alreadyCollected = true;
        }
    }

    void Update()
    {
        keyCounter.keys = player.collectedKey ? 1 : 0;

        if (player.collectedKey == true)
        {
            objectiveTextMesh.text = "Volte para a saida do andar.";
        }
        else
        {
            objectiveTextMesh.text = "Encontre a chave do portão para o proximo andar.";
        }
    }
}
