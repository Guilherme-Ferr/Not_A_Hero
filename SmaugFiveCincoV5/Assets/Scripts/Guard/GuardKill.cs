using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardKill : MonoBehaviour
{
    public GameOverManager gameOverManager;
    public GameObject gameOverUI;
    public GuardData guard;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && guard.aggro)
        {
            gameOverManager.GameOver(gameOverUI);
        }
    }
}
