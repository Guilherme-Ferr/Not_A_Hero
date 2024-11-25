using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GuardSound : MonoBehaviour
{
    public AudioSource stoneFootSoundEffect;
    private bool isPlayng;

    public void PlayFootSound()
    {
        if (!isPlayng)
        {
            stoneFootSoundEffect.Play();
            isPlayng = false;
        }
    }
}
