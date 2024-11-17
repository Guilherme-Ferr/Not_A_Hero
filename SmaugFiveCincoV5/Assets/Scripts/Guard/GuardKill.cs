using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardKill : MonoBehaviour
{
    public GameOverManager gameOverManager;
    public GameObject gameOverUI;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOverManager.GameOver(gameOverUI);
        }
    }
}
