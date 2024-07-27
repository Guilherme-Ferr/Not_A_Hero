using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PauseMenu pauseMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuGame()
    {
        SceneManager.LoadScene(0);
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pauseMenu.isPaused = false;
    }
}
