using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointManager cpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData player = collision.gameObject.GetComponent<PlayerData>();
            // Salvar a posição e o estado atual do player
            cpManager.SaveCheckpoint(player);
        }
    }
}
