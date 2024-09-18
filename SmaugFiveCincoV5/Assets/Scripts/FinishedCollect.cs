using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedCollect : MonoBehaviour
{
    // [SerializeField] public CollectVegetables collectVegetable;
    // public FadeManager fadeManager; // Referência ao FadeManager

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if (collider.gameObject.CompareTag("Player") && collectVegetable.finishedCollecting)
    //     {

    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    //         // Inicia o fade out antes de carregar a próxima fase
    //         // StartCoroutine(LoadNextSceneAfterFade());
    //     }
    // }

    // private IEnumerator LoadNextSceneAfterFade()
    // {
    //     // Inicia o fade out
    //     yield return StartCoroutine(fadeManager.FadeOut());

    //     // Carrega a próxima cena após o fade out
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
}
