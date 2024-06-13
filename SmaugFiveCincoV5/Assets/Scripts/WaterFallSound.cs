using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFallSound : MonoBehaviour
{
    public AudioSource waterfallAudio;
    public float maxDistance = 15f;
    private Transform playerTransform;
    public float fadeSpeed = 1f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(playerTransform.position, transform.position);
        float volume = 0.7f - Mathf.Clamp01(distance / maxDistance);

        if (distance <= maxDistance)
        {
            if (!waterfallAudio.isPlaying)
            {
                waterfallAudio.Play();
            }
            waterfallAudio.volume = Mathf.MoveTowards(waterfallAudio.volume, volume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            waterfallAudio.volume = Mathf.MoveTowards(waterfallAudio.volume, 0f, fadeSpeed * Time.deltaTime);
            if (waterfallAudio.volume == 0f && waterfallAudio.isPlaying)
            {
                waterfallAudio.Pause();
            }
        }
    }
}