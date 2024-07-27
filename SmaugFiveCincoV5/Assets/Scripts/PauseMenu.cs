using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Referência ao menu de pausa
    private bool isPaused = false;  // Flag para verificar se o jogo está pausado

    void Start()
    {
        Resume();
    }

    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("resume");
        pauseMenuUI.SetActive(false);  // Esconde o menu de pausa
        Time.timeScale = 1f;           // Retoma o tempo do jogo
        isPaused = false;              // Atualiza o estado de pausa
    }

    void Pause()
    {
        Debug.Log("pause");
        pauseMenuUI.SetActive(true);   // Mostra o menu de pausa
        Time.timeScale = 0f;           // Pausa o tempo do jogo
        isPaused = true;               // Atualiza o estado de pausa
    }
}
