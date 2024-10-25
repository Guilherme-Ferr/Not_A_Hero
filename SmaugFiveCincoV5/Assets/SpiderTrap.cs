using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderTrap : MonoBehaviour
{
    public PlayerData player;
    public PlayerMovement playerMovement;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

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
            anim.SetTrigger("spider");
            playerMovement.WalkingSpeed = 0;
            playerMovement.RunningSpeed = 0;
            playerMovement.CrouchingSpeed = 0;
            playerMovement.JumpForce = 0;


            Debug.Log("Sem tocha");
        }
        else
        {
            Debug.Log("Com tocha");
        }
    }
}
