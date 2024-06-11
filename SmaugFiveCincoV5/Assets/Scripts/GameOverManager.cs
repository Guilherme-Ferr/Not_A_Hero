using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public FadeManager fadeManager; // Referência ao FadeManager
    public List<GameObject> gameOverUIs; // Lista de UIs de Game Over, uma para cada tipo de morte
    public GameOverAnimationManager gameOverAnimationManager; // Referência ao GameOverAnimationManager
    private Dictionary<string, GameObject> gameOverUIDictionary;

    private void Start()
    {
        // gameOverAnimationManager.gameOverManager = this;

        // Inicializa o dicionário
        gameOverUIDictionary = new Dictionary<string, GameObject>();

        foreach (var ui in gameOverUIs)
        {
            string tag = ui.tag; // Certifique-se de que cada UI de Game Over tenha a tag correta
            if (!string.IsNullOrEmpty(tag) && !gameOverUIDictionary.ContainsKey(tag))
            {
                gameOverUIDictionary.Add(tag, ui);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Bird"))
        // {
        //     gameOverAnimationManager.PlayGameOverAnimation();
        // }
        // else 
        if (gameOverUIDictionary.TryGetValue(collision.gameObject.tag, out GameObject gameOverUI))
        {
            GameOver(gameOverUI);
        }
    }

    public void GameOver(GameObject gameOverUItoPlay)
    {
        gameOverUItoPlay.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Despausa o jogo
        fadeManager.RestartLevel(); // Chama o método de reiniciar com fade
    }
}