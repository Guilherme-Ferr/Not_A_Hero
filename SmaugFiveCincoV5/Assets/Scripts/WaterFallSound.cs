using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFallSound : MonoBehaviour
{
    public AudioSource waterfallAudio;
    public float maxDistance = 5f; // Máxima distância para ouvir o som
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assumindo que o player tem a tag "Player"
    }

    void Update()
    {
        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if (distance <= maxDistance)
        {
            if (!waterfallAudio.isPlaying)
            {
                waterfallAudio.Play();
            }
        }
        else
        {
            if (waterfallAudio.isPlaying)
            {
                waterfallAudio.Pause();
            }
        }
    }
}
