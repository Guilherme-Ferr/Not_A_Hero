using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] public AudioSource grassFootSoundEffect;
    [SerializeField] public AudioSource woodFootSoundEffect;
    public Tilemap currentTilemap;
    private string currentGround;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
        if (tilemap != null) currentGround = tilemap.name;
    }

    public void PlayFootStepsSound()
    {
        switch (currentGround)
        {
            case "Bridge":
                woodFootSoundEffect.Play();
                break;
            case "Terrain":
                grassFootSoundEffect.Play();
                break;
            default: break;
        }
    }
}
