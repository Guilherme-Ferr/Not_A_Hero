using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSound : MonoBehaviour
{
    public AudioSource grassFootSoundEffect;
    public AudioSource woodFootSoundEffect;
    public AudioSource stoneFootSoundEffect;
    public AudioSource chainSoundEffect;
    public AudioSource collectVegetationSoundEffect;
    private PlayerData playerData;
    public enum PlayerNoise { none, mid, loud }
    public PlayerNoise playerNoise;
    private string groundTag;
    private bool isPlayng;

    private void Start()
    {
        playerData = transform.GetComponent<PlayerData>();
    }

    private void Update()
    {
        UpdateNoiseState();
    }

    private void UpdateNoiseState()
    {
        playerNoise = playerData.state switch
        {
            PlayerData.PlayerMovementState.walkingSlingshot or
            PlayerData.PlayerMovementState.jumpingSlingshot or
            PlayerData.PlayerMovementState.fallingSlingshot or
            PlayerData.PlayerMovementState.landingSlingshot or
            PlayerData.PlayerMovementState.shootingSlingshot or
            PlayerData.PlayerMovementState.climbing => PlayerNoise.mid,
            PlayerData.PlayerMovementState.runningSlingshot => PlayerNoise.loud,
            _ => PlayerNoise.none,
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        groundTag = collision.gameObject.tag;
    }

    public void PlayFootSound()
    {
        switch (groundTag)
        {
            case "PrisonFloor":
                PlaySound(stoneFootSoundEffect);
                break;
            case "GrassFloor":
                PlaySound(grassFootSoundEffect);
                break;
            case "BridgeFloor":
                PlaySound(woodFootSoundEffect);
                break;
        }
    }

    private void PlaySound(AudioSource audioSource)
    {
        if (!isPlayng)
        {
            audioSource.Play();
            isPlayng = false;
        }
    }

    public void PlayChainSound()
    {
        chainSoundEffect.Play();
    }

    public void PlayCollectVegetation()
    {
        collectVegetationSoundEffect.Play();
    }
}
