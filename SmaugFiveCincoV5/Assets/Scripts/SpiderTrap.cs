using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderTrap : MonoBehaviour
{
    public PlayerData player;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public GameObject kill;
    private bool isKilling = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (!player.withTorch && !isKilling)
        {
            isKilling = true;
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
            anim.Play("spider", 0, 0f);
            anim.speed = 1f;
            player.collectedTorch = false;
        }
    }

    public IEnumerator SpiderKill()
    {
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
        kill.SetActive(true);
        yield return new WaitForSeconds(1f);
        kill.SetActive(false);
        isKilling = false;
    }
}
