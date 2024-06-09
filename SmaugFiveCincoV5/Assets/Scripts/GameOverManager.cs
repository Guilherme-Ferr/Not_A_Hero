using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // public GameObject gameOverSpiderUI;
    // public GameObject gameOverSpikeUI;
    // public GameObject gameOverGuardUI;
    // public GameObject gameOverPoisonUI;
    // public GameObject gameOverBirdUI;

    // public GameObject gameOverUIPrefab; // Prefab da UI de Game Over
    public List<GameObject> gameOverUIs; // Lista de UIs de Game Over, uma para cada tipo de morte

    private Dictionary<string, GameObject> gameOverUIDictionary;

    private void Start()
    {
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
        if (gameOverUIDictionary.TryGetValue(collision.gameObject.tag, out GameObject gameOverUI))
        {
            GameOver(gameOverUI);
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Spike"))
    //     {
    //         GameOver(gameOverSpikeUI);
    //     }
    // }

    void GameOver(GameObject gameOverUItoPlaye)
    {
        gameOverUItoPlaye.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }
}