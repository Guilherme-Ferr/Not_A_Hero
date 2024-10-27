using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public PlayerData player;
    public Checkpoint firstCheckpoint;

    void Start()
    {
        // player = transform.GetComponent<PlayerData>();
        // Inicializa o fade in
        StartCoroutine(FadeIn());
    }

    public void RestartLevel(GameObject gameOverUItoClose)
    {
        // Inicia o fade out antes de reiniciar a fase
        // StartCoroutine(FadeOutAndRestart(gameOverUItoClose));
        FadeOutAndRestart(gameOverUItoClose);
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
    }

    private void FadeOutAndRestart(GameObject gameOverUItoClose)
    {
        // yield return StartCoroutine(FadeOut());

        if (firstCheckpoint.checkpointReached)
        {
            // Restaurar posição e estado
            player.SetState();
            gameOverUItoClose.SetActive(false);
        }
        else
        {
            // Voltar para o início da fase ou outra lógica de morte
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
    }
}
