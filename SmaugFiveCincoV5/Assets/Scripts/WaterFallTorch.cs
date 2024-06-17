using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaterFallTorch : MonoBehaviour
{
    public PlayerData player;
    public AudioSource torchOffSoundEffect;
    public AudioSource torchContinuesSoundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.withTorch)
            {
                torchOffSoundEffect.Play();
                torchContinuesSoundEffect.Stop();
                player.withTorch = false;
            }
        }
    }
}
