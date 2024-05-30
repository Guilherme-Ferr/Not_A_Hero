using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] public AudioSource grassFootSoundEffect;
    [SerializeField] public AudioSource woodFootSoundEffect;
    // public Tilemap currentTilemap;
    private string currentGround;
    private string currentGroundTag;
    private PlayerData playerData;
    public enum PlayerNoise { none, mid, loud }
    private PlayerNoise playerNoise;

    private void Start()
    {
        playerData = transform.GetComponent<PlayerData>();
        playerNoise = playerData.GetComponent<PlayerNoise>();
    }

    private void Update()
    {
        UpdateNoiseState();
    }

    private void lingshotlisionStay2D(Collision2D collision)
    {
        Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
        if (tilemap != null)
        {
            currentGround = tilemap.name;
            currentGroundTag = tilemap.tag;
        }
    }

    public void PlayFootStepsSound()
    {
        switch (currentGround)
        {
            case "Bridge":
                woodFootSoundEffect.Play();
                break;
            case "Terrain":
                if (currentGroundTag == "PrisonFloor")
                {
                    woodFootSoundEffect.Play();
                }
                else
                {
                    grassFootSoundEffect.Play();
                }
                break;
            default: break;
        }
    }

    private void UpdateNoiseState()
    {
        playerNoise = playerData.state switch
        {
            PlayerData.PlayerMovementState.walking or
            PlayerData.PlayerMovementState.walkingSlingshot or
            PlayerData.PlayerMovementState.jumping or
            PlayerData.PlayerMovementState.falling => PlayerNoise.mid,
            PlayerData.PlayerMovementState.running or
            PlayerData.PlayerMovementState.runningSlingshot => PlayerNoise.loud,
            _ => PlayerNoise.none,
        };
    }

}
