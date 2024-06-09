using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerData player;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerData>();
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Spike"))
    //     {
    //         Die();
    //     }
    // }

    // public void Die()
    // {
    //     player.dead = true;
    //     rb.bodyType = RigidbodyType2D.Static;
    //     RestartLevel();
    // }

    // public void RestartLevel()
    // {
    //     Debug.Log("dieou");

    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
