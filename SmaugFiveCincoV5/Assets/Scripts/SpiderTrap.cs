using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderTrap : MonoBehaviour
{
    public PlayerData player;
    private Animator anim;
    public GameObject kill;
    // public FadeManager fadeManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        // anim.Play("spider", 0, 0f);
        // anim.speed = 0f; // Pausa no primeiro frame
    }

    public void ResetSpider()
    {
        anim.Play("spider", 0, 0f);
        anim.speed = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ComTocha();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !player.withTorch)
        {
            player.movement.rb.bodyType = RigidbodyType2D.Static;
        }
    }

    void ComTocha()
    {
        if (!player.withTorch)
        {
            anim.SetTrigger("spider");
            anim.speed = 1f;
            player.collectedTorch = false;
        }
    }

    public void SpiderKill()
    {
        kill.SetActive(true);
    }
}
