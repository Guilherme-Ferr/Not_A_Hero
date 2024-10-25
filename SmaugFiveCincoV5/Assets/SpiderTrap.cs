using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderTrap : MonoBehaviour
{
    public PlayerData player;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            ComTocha();  
        }
    }

    void ComTocha()
    {
        if (!player.withTorch)
        {
            SceneManager.LoadScene(2);
            Debug.Log("Sem tocha");
        }
        else
        {
            Debug.Log("Com tocha");
        }
    }
}
