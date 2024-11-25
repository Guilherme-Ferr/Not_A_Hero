using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GuardSound : MonoBehaviour
{
    public AudioSource stoneFootSoundEffect;
    public Transform player;
    public float detectionRadius = 8f;
    private bool isPlaying;

    public void PlayFootSound()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            stoneFootSoundEffect.volume = Mathf.Lerp(0, 0.1f, 1 - (distanceToPlayer / detectionRadius));
            stoneFootSoundEffect.Play();
            StartCoroutine(ResetIsPlaying(stoneFootSoundEffect.clip.length));
        }
        else
        {
            stoneFootSoundEffect.volume = 0;
        }
    }

    private IEnumerator ResetIsPlaying(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPlaying = false;
    }
}
