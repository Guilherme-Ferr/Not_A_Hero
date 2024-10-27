using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // public CheckpointManager cpManager;
    public bool checkpointReached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData player = collision.gameObject.GetComponent<PlayerData>();
            // Salvar a posição e o estado atual do player
            checkpointReached = true;
            player.SaveState(player);
        }
    }
}
