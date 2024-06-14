using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaterFallTorch : MonoBehaviour
{
    public PlayerData player;
    public AudioSource torchOffSoundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.withTorch = false;
            torchOffSoundEffect.Play();
        }
    }
}
